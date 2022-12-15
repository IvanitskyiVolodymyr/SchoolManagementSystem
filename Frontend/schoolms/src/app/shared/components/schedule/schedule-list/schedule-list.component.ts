import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { DateRange } from 'src/app/shared/models/date/date-range';
import { ScheduleAttendance } from 'src/app/shared/models/schedule/scheduleAttendance';
import { ScheduleDay } from 'src/app/shared/models/schedule/scheduleDay';
import { ResponseTask } from 'src/app/shared/models/tasks/reposponseTask';
import { ScheduleService } from 'src/app/shared/services/schedule.service';
import { TasksService } from 'src/app/shared/services/tasks.service';
import { entityWithRole } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-schedule-list',
  templateUrl: './schedule-list.component.html',
  styleUrls: ['./schedule-list.component.scss']
})
export class ScheduleListComponent implements OnInit {

  public schedules: Array<ScheduleAttendance> = [];
  public homeworks: Array<ResponseTask> = [];
  public scheduleDays: Array<ScheduleDay> = [] as Array<ScheduleDay>;
  
  public startDate: Date = new Date();
  public finishDate: Date = new Date();
  public isFromWeekBegining = true;
  public daysDiff: number = 7;


  private studentId: number = 1 as number;

  constructor(
    private scheduleService: ScheduleService,
    private taskService: TasksService,
    private store: Store
  ) {
      
  }
  ngOnInit(): void {
    this.store.select(entityWithRole).subscribe(
      result => {
        this.studentId = result?.entityId as number;
      }
    );
  }

  private getSchedulesByDate(startDate: Date, finishDate: Date, studentId: number) {
    this.scheduleService.GetScheduleForStudentWithAttendancesByPeriod(startDate, finishDate, studentId)
    .subscribe((result) => {
        this.groupScheduleByDays(result);
    });

    this.taskService.GetAllHomeworksForStudent(studentId, startDate, finishDate).subscribe(
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
    this.scheduleDays = this.scheduleDays.sort((b, a) => new Date(b.date).getTime() - new Date(a.date).getTime())
  }

  public getHomework(scheduleId: number) {
    return this.homeworks.filter((element) => element.scheduleId === scheduleId);
  }

  public onDateRangeChanged(date: DateRange) {
    this.getSchedulesByDate(date.startDate, date.endDate, this.studentId);
  }

}
