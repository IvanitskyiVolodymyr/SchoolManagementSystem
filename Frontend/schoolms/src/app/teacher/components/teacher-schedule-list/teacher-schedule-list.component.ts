import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { DateRange } from 'src/app/shared/models/date/date-range';
import { ScheduleWithClassSubject } from 'src/app/shared/models/schedule/scheduleWithClassSubject';
import { TeacherScheduleDay } from 'src/app/shared/models/schedule/teacherScheduleDay';
import { ResponseTask } from 'src/app/shared/models/tasks/reposponseTask';
import { ScheduleService } from 'src/app/shared/services/schedule.service';
import { TasksService } from 'src/app/shared/services/tasks.service';
import { entityWithRole } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-teacher-schedule-list',
  templateUrl: './teacher-schedule-list.component.html',
  styleUrls: ['./teacher-schedule-list.component.scss']
})
export class TeacherScheduleListComponent {

  public schedules: Array<ScheduleWithClassSubject> = [];
  public homeworks: Array<ResponseTask> = [];
  public scheduleDays: Array<TeacherScheduleDay> = [] as Array<TeacherScheduleDay>;

  public startDate: Date = new Date();
  public finishDate: Date = new Date();
  public isFromWeekBegining = true;
  public daysDiff = 7;
  private teacherId: number = 1 as number;

  constructor(
    private scheduleService: ScheduleService,
    private taskService: TasksService,
    private store: Store
  ) {
      
  }
  ngOnInit(): void {
    this.store.select(entityWithRole).subscribe(
      result => {
        this.teacherId = result?.entityId as number;
      }
    );
  }

  public getClassForTimeLine(startTime: Date, endTime: Date) {
    const currentDate = new Date();
    if(new Date(endTime).getTime() < currentDate.getTime())
      return 'is-done';
    else if(new Date(startTime).getTime() > currentDate.getTime())
      return '';
    else
      return 'current';
  }

  private groupScheduleByDays(sa: ScheduleWithClassSubject[]) {
    this.scheduleDays = [];
    this.schedules = sa;
    const map = new Map<number, Array<ScheduleWithClassSubject>>();

    this.schedules.forEach(lesson => {
      const dateDay = new Date(lesson.startTime).getDate();

      if(!map.get(dateDay)) {
        map.set(dateDay, [])
      }
      const array = map.get(dateDay);
      array?.push(lesson);
    });

    map.forEach(day =>{
      const scheduleDay: TeacherScheduleDay = {
        date: day[0].startTime,
        schedules: day.sort((b, a) => new Date(b.startTime).getTime() - new Date(a.startTime).getTime())
      };

      this.scheduleDays.push(scheduleDay);
    });
    this.scheduleDays = this.scheduleDays.sort((b, a) => new Date(b.date).getTime() - new Date(a.date).getTime())
  }


  public onDateRangeChanged(date: DateRange) {
    this.scheduleService.GetScheduleForTeacherByPeriod(date.startDate, date.endDate, this.teacherId).subscribe(
      result => {
        this.schedules = result;
        console.log(result);
        this.groupScheduleByDays(result);
      }
    );
  }

  public getPlanning(scheduleId: number) {
    return "qqqqqqqqqqqqqqqq";
  }
}
