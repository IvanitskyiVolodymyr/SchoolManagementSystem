import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { DateRange } from 'src/app/shared/models/date/date-range';
import { ScheduleCardModel } from 'src/app/shared/models/schedule/scheduleCardModel';
import { ScheduleWithClassSubject } from 'src/app/shared/models/schedule/scheduleWithClassSubject';
import { DateRangeService } from 'src/app/shared/services/date-range.service';
import { ScheduleService } from 'src/app/shared/services/schedule.service';
import { entityWithRole } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-teacher-schedule-base',
  templateUrl: './teacher-schedule-base.component.html',
  styleUrls: ['./teacher-schedule-base.component.scss']
})
export class TeacherScheduleBaseComponent implements OnInit, OnDestroy {

  private teacherId: number | undefined;
  public schedules: Array<ScheduleCardModel> = [];

  private subscription!: Subscription;

  constructor(
    private scheduleService: ScheduleService,
    private store: Store,
    private dateRangeService: DateRangeService
  ) { }

  ngOnInit(): void {
    this.store.select(entityWithRole).subscribe(
      result => {
        this.teacherId = result?.entityId as number;
        this.subscription = this.dateRangeService.dateRangeEvent.subscribe(
          dateRange => {
            this.onDateChanged(dateRange, this.teacherId);
          }
        );
      }
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  private getSchedulesByDate(startDate: Date, finishDate: Date, teacherId: number) {

        this.scheduleService.GetScheduleForTeacherByPeriod(startDate, finishDate, teacherId)
        .subscribe((result) => {
          const mappedResut = result.map(e => {
            return {
              classSubjectId: e.classSubjectId,
              startTime: e.startTime,
              endTime: e.endTime,
              place: e.place,
              scheduleId: e.scheduleId,
              title: e.subjectName + this.getClassNumberWithLetter(e),
              rightPart: '',
              homeworks: [],
              planning: ['Вивчення кислот']
            } as ScheduleCardModel
          });  
          this.schedules = mappedResut;
      });
  }

  public onDateChanged(date: DateRange, teacherId: number | undefined) {
    if(teacherId)
      this.getSchedulesByDate(date.startDate, date.endDate, teacherId);
  }

  private getClassNumberWithLetter(schedule: ScheduleWithClassSubject): string {
    let result = ' (';
    if(schedule.classNumber)
      result += schedule.classNumber;
    if(schedule.classLetter)
      result += schedule.classLetter;
    result += ')';
    return result;
  }
}
