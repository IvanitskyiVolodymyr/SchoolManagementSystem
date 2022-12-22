import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatMenuTrigger } from '@angular/material/menu';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { AddLinkDialogComponent } from 'src/app/shared/components/add-link-dialog/add-link-dialog.component';
import { StudentTaskAttachment } from 'src/app/shared/models/attachments/studentTaskAttachment';
import { ResponseTaskWithGradeAndAttachments } from 'src/app/shared/models/tasks/responseTaskWithGradeAndAttachments';
import { TasksService } from 'src/app/shared/services/tasks.service';
import { removeStudentTaskAttachment } from 'src/app/store/actions/student.actions';
import { selectStudentTaskAttachments } from 'src/app/store/selectors/user.selector';

@Component({
  selector: 'app-task-info',
  templateUrl: './task-info.component.html',
  styleUrls: ['./task-info.component.scss']
})
export class TaskInfoComponent implements OnInit{

  @ViewChild('addAttachmentTrigger') attachmentTrigger: MatMenuTrigger = {} as MatMenuTrigger;
  public task: ResponseTaskWithGradeAndAttachments = { } as ResponseTaskWithGradeAndAttachments;
  public attachments: Array<StudentTaskAttachment> = [];
  public statusColor = '#E4F6D0';

  constructor(public dialog: MatDialog,
      private taskService: TasksService,
      private router: ActivatedRoute,
      private store: Store) {}

  ngOnInit(): void {
    this.router.params.subscribe(params => {
      this.taskService.GetTaskWithStatusAndAttachments(params['id']).subscribe(
        (result) => {
          this.task = result;
          console.log(result);
          this.setStatusColor();
          this.getStudentTaskFromStorage(result.studentTaskId);
        }
      )
    });
  }

  private setStatusColor() {
    if(this.task.isChecked) {
      this.statusColor = '#80BBA0';
    }
    else {
      if(this.task.isDone) {
        this.statusColor = '#DEAE77';
      } else {
        this.statusColor = '#DE0000';
      }
    }
  }

  private getStudentTaskFromStorage(studentTaskId: number) {
    this.store.select(selectStudentTaskAttachments(studentTaskId)).subscribe(
      result => {
        if(result?.length > 0) {
          this.attachments = result[0].attachments;
        } else {
          this.attachments = this.task.attachments;
        }
      }
    );
  }

  openAttachLinkDialog() {
    const dialogRef = this.dialog.open(AddLinkDialogComponent, {restoreFocus: false, data: {studentTaskId: this.task.studentTaskId}});
    dialogRef.afterClosed().subscribe(() => this.attachmentTrigger.focus());
  }

  submitTask() {
    this.taskService.SubmitStudentTask([],this.task.studentTaskId).subscribe(
      res => console.log("Return data: " + res)
    );
  }

  remove(attachment: StudentTaskAttachment): void {

    this.store.dispatch(removeStudentTaskAttachment({studentTaskId: this.task.studentTaskId, attachment: attachment}));
  }

}
