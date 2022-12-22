import { DatePipe } from '@angular/common';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { StudentTaskAttachment } from '../models/attachments/studentTaskAttachment';
import { ResponseTask } from '../models/tasks/reposponseTask';
import { ResponseTaskWithGrade } from '../models/tasks/responseTaskWithGrade';
import { ResponseTaskWithGradeAndAttachments } from '../models/tasks/responseTaskWithGradeAndAttachments';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class TasksService {
  
  private prefix = "/tasks";
  constructor(
    private httpService: HttpClientService,
    private datePipe: DatePipe
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
    new HttpParams()
    .set('studentId', studentId)
    .set('from', this.datePipe.transform(from, 'MMM d, y, h:mm:ss a') as string)
    .set('to', this.datePipe.transform(to, 'MMM d, y, h:mm:ss a') as string))
      .pipe(
        map(
          (resp) => {
            return resp.body as Array<ResponseTaskWithGrade>;
          })
      )
  }

  public GetTaskWithStatusAndAttachments(studentTaskId: number): Observable<ResponseTaskWithGradeAndAttachments> {
    return this.httpService.getFullRequest<ResponseTaskWithGradeAndAttachments>(`${this.prefix}/GetTaskWithStatusAndAttachments`,
    new HttpParams()
    .set('studentTaskId', studentTaskId))
      .pipe(
        map(
          (resp) => {
            return resp.body as ResponseTaskWithGradeAndAttachments;
          })
      )
  }

  public SubmitStudentTask(attachments: Array<StudentTaskAttachment>,studentTaskId: number): Observable<number> {
    const params = new HttpParams()
    .set('studentTaskId', studentTaskId);

    return this.httpService.postFullRequest<number>(`${this.prefix}/SubmitStudentTask`, attachments, undefined, params )
      .pipe(
        map(
          (resp) => {
            return resp.body as number;
          })
      )
  }
}
