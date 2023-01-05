import { Component, OnInit } from '@angular/core';
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
export class StudentScheduleBaseComponent implements OnInit{

  private studentId: number = 1 as number;
  public schedules: Array<ScheduleCardModel> = [];
  public homeworks: Array<ResponseTask> = [];

  private subscription!: Subscription;

  constructor(
    private scheduleService: ScheduleService,
    private taskService: TasksService,
    private store: Store,
    private dateRangeService: DateRangeService
  ) { }

  ngOnInit(): void {
    this.subscription = this.dateRangeService.dateRangeEvent.subscribe(
      dateRange => {
        this.onDateChanged(dateRange);
      }
    );

    this.store.select(entityWithRole).subscribe(
      result => {
        this.studentId = result?.entityId as number;
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

  public onDateChanged(date: DateRange) {
    this.getSchedulesByDate(date.startDate, date.endDate, this.studentId);
  }

  private getHomework(tasks: ResponseTask[], scheduleId: number) : Array<string> {
    let homeworks = tasks.filter(t => t.scheduleId === scheduleId);
    return homeworks.map(hw => hw.title);
  }

  private getStatus(status: AttendanceStatus | null): string {
    let result = '';
    if(status === 1)
      result = 'Н';
    if(status === 2)
      result = 'Х';
    return result;
  }

}
