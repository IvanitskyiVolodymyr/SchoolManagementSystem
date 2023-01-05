import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ScheduleAttendance } from '../models/schedule/scheduleAttendance';
import { ScheduleWithClassSubject } from '../models/schedule/scheduleWithClassSubject';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  private prefix = "/schedule";
  constructor(
    private httpService: HttpClientService
  ) { }

  public GetScheduleForStudentWithAttendancesByPeriod(from: Date, to: Date, studentId: number ) : Observable<Array<ScheduleAttendance>> {
    return this.httpService.get<Array<ScheduleAttendance>>(`${this.prefix}/students/schedules-with-attendances`,
    new HttpParams().set('startDateTime', from.toDateString()).set('endDateTime', to.toDateString()).set('studentId', studentId));
  }

  public GetScheduleForTeacherByPeriod(from: Date, to: Date, teacherId: number ) : Observable<Array<ScheduleWithClassSubject>> {
    return this.httpService.get<Array<ScheduleWithClassSubject>>(`${this.prefix}/teachers`,
    new HttpParams().set('startDateTime', from.toDateString()).set('endDateTime', to.toDateString()).set('teacherId', teacherId));
  }
}
