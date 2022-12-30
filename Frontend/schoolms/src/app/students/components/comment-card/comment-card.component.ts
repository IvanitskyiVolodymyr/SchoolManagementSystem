import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { ActiveCommentInterface } from 'src/app/shared/models/comments/activeComment.interface';
import { ActiveCommentTypeEnum } from 'src/app/shared/models/comments/activeCommentType.enum';
import { StudentTaskComment } from 'src/app/shared/models/comments/studentTaskComment';
import { userSelector } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-comment-card',
  templateUrl: './comment-card.component.html',
  styleUrls: ['./comment-card.component.scss']
})
export class CommentCardComponent implements OnInit{

  @Input() comment!: StudentTaskComment;
  @Input() replies!: StudentTaskComment[];
  @Input() parentId!: number | null;

  @Output() setActiveComment = new EventEmitter<ActiveCommentInterface | null>();
  @Output() addComment = new EventEmitter<{ text: string; commentParentId: number | undefined }>();
  @Output() updateComment = new EventEmitter<{ text: string; commentId: number }>();
  @Output() deleteComment = new EventEmitter<StudentTaskComment>();

  activeCommentType = ActiveCommentTypeEnum;
  @Input() activeComment: ActiveCommentInterface| null = null;

  public replyId: number | undefined;

  public canEdit = false;
  public canDelete = false;
  public canReply = false;

  constructor(private store: Store) { }

  ngOnInit(): void {
    this.store.select(userSelector).subscribe(
      (user) => {
        if(user)
          this.setCommentPermissions(user.userId);
          this.replyId = this.parentId ? this.parentId : this.comment.studentTaskCommentId;
      }
    )

  }

  private setCommentPermissions(currentUserId: number) {
    const fiveMinutes = 300000;
    const timeDiff = new Date().getTime() - new Date(this.comment.createdAt).getTime();
    const timePassed = timeDiff > fiveMinutes;
    this.canReply = !this.comment.commentParentId;
    this.canEdit = currentUserId === this.comment.shortUserInfo.userId && !timePassed;
    this.canDelete =
      currentUserId === this.comment.shortUserInfo.userId &&
      this.replies.length === 0 && !timePassed;
  }

  public isReplying(): boolean {
    if (!this.activeComment) {
      return false;
    }
    return (
      this.activeComment.id === this.comment.studentTaskCommentId &&
      this.activeComment.type === this.activeCommentType.replying
    );
  }

  public isEditing(): boolean {
    if (!this.activeComment) {
      return false;
    }
    return (
      this.activeComment.id === this.comment.studentTaskCommentId &&
      this.activeComment.type === this.activeCommentType.editing
    );
  }

  public onCancelClicked() {
    this.activeComment = null;
  }
}
