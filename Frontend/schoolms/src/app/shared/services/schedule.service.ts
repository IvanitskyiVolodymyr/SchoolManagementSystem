import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ScheduleAttendance } from '../models/schedule/scheduleAttendance';
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
}
