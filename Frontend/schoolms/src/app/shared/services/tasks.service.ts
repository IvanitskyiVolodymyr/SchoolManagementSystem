import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ResponseTask } from '../models/tasks/reposponseTask';
import { ResponseTaskWithGrade } from '../models/tasks/responseTaskWithGrade';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
  
  private prefix = "/tasks";
  constructor(
    private httpService: HttpClientService
  ) { }

  public GetAllHomeworksForStudent(studentId: number, from: Date, to: Date) :Observable<Array<ResponseTask>>{
    return this.httpService.getFullRequest<Array<ResponseTask>>(`${this.prefix}/GetAllHomeworksForStudent`,
    new HttpParams().set('studentId', studentId).set('from', from.toDateString()).set('to', to.toDateString()))
    .pipe(
      map(
        (resp) => {
          return resp.body as Array<ResponseTask>;
        })
    )
  }

  public GetAllTasksWithGradesForStudent(studentId: number, from: Date, to: Date): Observable<Array<ResponseTaskWithGrade>> {
    return this.httpService.getFullRequest<Array<ResponseTaskWithGrade>>(`${this.prefix}/GetAllTasksWithGradesForStudent`,
    new HttpParams().set('studentId', studentId).set('from', from.toDateString()).set('to', to.toDateString()))
    .pipe(
      map(
        (resp) => {
          return resp.body as Array<ResponseTaskWithGrade>;
        })
    )
  }
}
