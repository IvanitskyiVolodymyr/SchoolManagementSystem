import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateCommentModel } from '../models/comments/createCommentModel';
import { StudentTaskComment } from '../models/comments/studentTaskComment';
import { UpdateCommentModel } from '../models/comments/updateCommentModel';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  private prefix = "/comments";
  
  constructor(
    private httpService: HttpClientService,
  ) { }

  public GetCommentsByStudentTaskId(studentTaskId: number): Observable<Array<StudentTaskComment>> {
    return this.httpService.get<Array<StudentTaskComment>>(`${this.prefix}/student-tasks/${studentTaskId}`);
  }

  public CreateComment(comment: CreateCommentModel): Observable<StudentTaskComment> {
    return this.httpService.post<StudentTaskComment>(`${this.prefix}`, comment);
  }

  public UpdateComment(comment: UpdateCommentModel): Observable<StudentTaskComment> {
    return this.httpService.put<StudentTaskComment>(`${this.prefix}`, comment);
  }

  public DeleteComment(studentTaskCommentId: number): Observable<number> {
    return this.httpService.delete<number>(`${this.prefix}/${studentTaskCommentId}`);
  }
}
