import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { DateRange } from 'src/app/shared/models/date/date-range';
import { AttendanceStatus } from 'src/app/shared/models/schedule/attendanceStatus';
import { ScheduleCardModel } from 'src/app/shared/models/schedule/scheduleCardModel';
import { ResponseTask } from 'src/app/shared/models/tasks/reposponseTask';
import { DateRangeService } from 'src/app/shared/services/date-range.service';
import { ScheduleService } from 'src/app/shared/services/schedule.service';
import { TasksService } from 'src/app/shared/services/tasks.service';
import { entityWithRole } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-student-schedule-base',
  templateUrl: './student-schedule-base.component.html',
  styleUrls: ['./student-schedule-base.component.scss']
})
export class StudentScheduleBaseComponent implements OnInit, OnDestroy {

  private studentId: number | undefined;
  public schedules: Array<ScheduleCardModel> = [];

  private subscription!: Subscription;

  constructor(
    private scheduleService: ScheduleService,
    private taskService: TasksService,
    private store: Store,
    private dateRangeService: DateRangeService
  ) { }

  ngOnInit(): void {
    this.store.select(entityWithRole).subscribe(
      result => {
        this.studentId = result?.entityId as number;
        this.subscription = this.dateRangeService.dateRangeEvent.subscribe(
          dateRange => {
            this.onDateChanged(dateRange, this.studentId);
          }
        );
      }
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  private getSchedulesByDate(startDate: Date, finishDate: Date, studentId: number) {
    if(studentId) {
      this.taskService.GetAllHomeworksForStudent(studentId, startDate, finishDate).subscribe(
        (homeWorks) => {
          this.scheduleService.GetScheduleForStudentWithAttendancesByPeriod(startDate, finishDate, studentId)
          .subscribe((result) => {
            const mappedResut = result.map(e => {
              return {
                classSubjectId: e.classSubjectId,
                startTime: e.startTime,
                endTime: e.endTime,
                place: e.place,
                scheduleId: e.scheduleId,
                title: e.subjectName,
                rightPart: this.getStatus(e.status),
                homeworks: this.getHomework(homeWorks, e.scheduleId),
                planning: []
              } as ScheduleCardModel
            });  
            this.schedules = mappedResut;
        });
        }
      );
  }
  }

  public onDateChanged(date: DateRange, studentId: number | undefined) {
    if(studentId)
      this.getSchedulesByDate(date.startDate, date.endDate, studentId);
  }

  private getHomework(tasks: ResponseTask[], scheduleId: number) : Array<string> {
    const homeworks = tasks.filter(t => t.scheduleId === scheduleId);
    return homeworks.map(hw => hw.title);
  }

  private getStatus(status: AttendanceStatus | null): string {
    let result = '';
    if(status === 1)
      result = '??';
    if(status === 2)
      result = '??';
    return result;
  }

}
