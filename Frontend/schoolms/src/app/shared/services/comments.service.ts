import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
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
    const params = new HttpParams()
    .set('studentTaskId', studentTaskId);

    return this.httpService.getFullRequest<Array<StudentTaskComment>>(`${this.prefix}/get-comments-by-student-task-id`, params )
      .pipe(
        map(
          (resp) => {
            return resp.body as Array<StudentTaskComment>;
          })
      )
  }

  public CreateComment(comment: CreateCommentModel): Observable<StudentTaskComment> {
    return this.httpService.postFullRequest<StudentTaskComment>(`${this.prefix}/create-comment`, comment )
      .pipe(
        map(
          (resp) => {
            return resp.body as StudentTaskComment;
          })
      )
  }

  public UpdateComment(comment: UpdateCommentModel): Observable<StudentTaskComment> {
    return this.httpService.putFullRequest<StudentTaskComment>(`${this.prefix}/update-comment`, comment )
      .pipe(
        map(  
          (resp) => {
            return resp.body as StudentTaskComment;
          })
      )
  }
}
