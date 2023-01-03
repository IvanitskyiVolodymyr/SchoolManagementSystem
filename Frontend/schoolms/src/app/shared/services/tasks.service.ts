import { DatePipe } from '@angular/common';
import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
    return this.httpService.get<Array<ResponseTask>>(`${this.prefix}/students/${studentId}/home-works`,
    new HttpParams().set('from', from.toDateString()).set('to', to.toDateString()));
  }

  public GetAllTasksWithGradesForStudent(studentId: number, from: Date, to: Date): Observable<Array<ResponseTaskWithGrade>> {
    return this.httpService.get<Array<ResponseTaskWithGrade>>(`${this.prefix}/students/${studentId}/tasks-with-grades`,
    new HttpParams()
    .set('from', this.datePipe.transform(from, 'MMM d, y, h:mm:ss a') as string)
    .set('to', this.datePipe.transform(to, 'MMM d, y, h:mm:ss a') as string));
  }

  public GetTaskWithStatusAndAttachments(studentTaskId: number): Observable<ResponseTaskWithGradeAndAttachments> {
    return this.httpService.get<ResponseTaskWithGradeAndAttachments>(`${this.prefix}/${studentTaskId}/tasks-with-attachments`);
  }

  public SubmitStudentTask(attachments: Array<StudentTaskAttachment>,studentTaskId: number): Observable<number> {
    return this.httpService.post<number>(`${this.prefix}/${studentTaskId}/submit`, attachments );
  }

  public CancelSubmitStudentTask(studentTaskId: number): Observable<number> {
    return this.httpService.post<number>(`${this.prefix}/${studentTaskId}/cancel`,{} );
  }
}
