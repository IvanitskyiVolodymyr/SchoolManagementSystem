import { Component, Input } from '@angular/core';
import { ScheduleCardModel } from 'src/app/shared/models/schedule/scheduleCardModel';
import { ScheduleDay } from 'src/app/shared/models/schedule/scheduleDay';

@Component({
  selector: 'app-schedule-list',
  templateUrl: './schedule-list.component.html',
  styleUrls: ['./schedule-list.component.scss']
})
export class ScheduleListComponent {

  @Input() public schedules: Array<ScheduleCardModel> = [];

  public scheduleDays: Array<ScheduleDay> = [] as Array<ScheduleDay>;
  
  public startDate: Date = new Date();
  public isFromWeekBegining = true;
  public daysDiff = 7;

  ngOnChanges() {
    this.groupScheduleByDays(this.schedules);
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
  
  private groupScheduleByDays(sa: ScheduleCardModel[]) {
    this.scheduleDays = [];
    this.schedules = sa;
    const map = new Map<number, Array<ScheduleCardModel>>();

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

}
