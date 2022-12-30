import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ActiveCommentInterface } from 'src/app/shared/models/comments/activeComment.interface';
import { CreateCommentModel } from 'src/app/shared/models/comments/createCommentModel';
import { StudentTaskComment } from 'src/app/shared/models/comments/studentTaskComment';
import { CommentsService } from 'src/app/shared/services/comments.service';
import { userSelector } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent implements OnInit{

@Input() studentTaskId!: number;
public comments: Array<StudentTaskComment> = [];
private userId = 0;
public activeComment: ActiveCommentInterface | null = null;

constructor(private commentsService: CommentsService,
  private store: Store) { }

  ngOnInit(): void {
      this.getComments(this.studentTaskId);
      this.getUserFromStore();
  }

  addComment(text: string, commentParentId: number | undefined): void {
    const comment = {comment: text, userId: this.userId, studentTaskId: this.studentTaskId, commentParentId: commentParentId} as CreateCommentModel;
    this.commentsService.CreateComment(comment).subscribe(
      (comment) => {
        this.comments = [...this.comments, comment];
        this.activeComment = null;
      }
    )
  }

  private getComments(studentTaskId: number) {
    this.commentsService.GetCommentsByStudentTaskId(studentTaskId)
    .subscribe(
      (comments) => {
        this.comments = comments;
      }
    )
  }

  private getUserFromStore() {
    this.store.select(userSelector).subscribe(
      (user) => {
        if(user)
          this.userId = user.userId;
      }
    )
  }

  public getReplies(commentId: number): StudentTaskComment[] {
    return this.comments
      .filter((comment) => comment.commentParentId === commentId)
      .sort(
        (a, b) =>
          new Date(a.createdAt).getTime() - new Date(b.createdAt).getTime()
      );
  }

  public setActiveComment(activeComment: ActiveCommentInterface | null): void {
    this.activeComment = activeComment;
  }
}
