import { Component, OnInit } from '@angular/core';
import { ScheduleAttendance } from 'src/app/shared/models/schedule/scheduleAttendance';
import { ScheduleDay } from 'src/app/shared/models/schedule/scheduleDay';
import { ResponseTask } from 'src/app/shared/models/tasks/reposponseTask';
import { ScheduleService } from 'src/app/shared/services/schedule.service';
import { TasksService } from 'src/app/shared/services/tasks.service';

@Component({
  selector: 'app-schedule-list',
  templateUrl: './schedule-list.component.html',
  styleUrls: ['./schedule-list.component.scss']
})
export class ScheduleListComponent implements OnInit {

  public schedules: Array<ScheduleAttendance> = [];
  public homeworks: Array<ResponseTask> = [];
  public scheduleDays: Array<ScheduleDay> = [] as Array<ScheduleDay>;
  public startDate: Date = {} as Date;
  public finishDate: Date = {} as Date;

  constructor(
    private scheduleService: ScheduleService,
    private taskService: TasksService
  ) {
      
  }
  ngOnInit(): void {
    this.getSchedulesByDate(new Date());
  }

  private getSchedulesByDate(date: Date) {
    const periodOfDates = this.getPeriodOfDate(date);

    this.scheduleService.GetScheduleForStudentWithAttendancesByPeriod(periodOfDates.startDate, periodOfDates.finishDate, 1)
    .subscribe((result) => {
        this.groupScheduleByDays(result);
    });

    this.taskService.GetAllHomeworksForStudent(1, periodOfDates.startDate, periodOfDates.finishDate).subscribe(
      (result) => {
        this.homeworks = result;
      }
    );
  }

  private groupScheduleByDays(sa: ScheduleAttendance[]) {
    this.scheduleDays = [];
    this.schedules = sa;
    const map = new Map<number, Array<ScheduleAttendance>>();

    this.schedules.forEach(lesson => {
      const dateDay = new Date(lesson.startTime).getDate();

      if(!map.get(dateDay)) {
        map.set(dateDay, [])
      }
      const array = map.get(dateDay);
      array?.push(lesson);
    });

    map.forEach(day =>{
      const scheduleDay: ScheduleDay = {
        date: day[0].startTime,
        schedules: day.sort((b, a) => new Date(b.startTime).getTime() - new Date(a.startTime).getTime())
      };

      this.scheduleDays.push(scheduleDay);
    });
  }

  private getPeriodOfDate(date: Date) {
    const startDate = new Date(date);
    startDate.setDate(startDate.getDate() - startDate.getDay() +1 );
    startDate.setHours(0);
    startDate.setMinutes(0);
    startDate.setSeconds(0);
    this.startDate = startDate;

    const finishDate = date;
    finishDate.setDate(finishDate.getDate() + 7 - finishDate.getDay());
    finishDate.setHours(23);
    finishDate.setMinutes(59);
    finishDate.setSeconds(59);
    this.finishDate = finishDate;

    return { startDate, finishDate };
  }

  public onPreviousWeekClick() {
    const finishDate = new Date(this.startDate.getTime() - 7*24*60*60*1000);

    this.getSchedulesByDate(finishDate);
  }

  public onNextWeekClick() {
    const finishDate = new Date(this.startDate.getTime() + 7*24*60*60*1000);
    this.getSchedulesByDate(finishDate);
  }

  public getHomework(scheduleId: number) {
    return this.homeworks.filter((element) => element.scheduleId === scheduleId);
  }

}
