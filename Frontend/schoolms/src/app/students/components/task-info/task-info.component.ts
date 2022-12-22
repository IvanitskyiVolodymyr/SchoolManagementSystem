import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatMenuTrigger } from '@angular/material/menu';
import { ActivatedRoute } from '@angular/router';
import { AddLinkDialogComponent } from 'src/app/shared/components/add-link-dialog/add-link-dialog.component';
import { StudentTaskAttachment } from 'src/app/shared/models/attachments/studentTaskAttachment';
import { ResponseTaskWithGradeAndAttachments } from 'src/app/shared/models/tasks/responseTaskWithGradeAndAttachments';
import { TasksService } from 'src/app/shared/services/tasks.service';

@Component({
  selector: 'app-task-info',
  templateUrl: './task-info.component.html',
  styleUrls: ['./task-info.component.scss']
})
export class TaskInfoComponent implements OnInit{

  @ViewChild('addAttachmentTrigger') attachmentTrigger: MatMenuTrigger = {} as MatMenuTrigger;
  public task: ResponseTaskWithGradeAndAttachments = { } as ResponseTaskWithGradeAndAttachments;
  public statusColor = '#E4F6D0';

  constructor(public dialog: MatDialog,
      private taskService: TasksService,
      private router: ActivatedRoute) {}

  ngOnInit(): void {
    this.router.params.subscribe(params => {
      this.taskService.GetTaskWithStatusAndAttachments(params['id']).subscribe(
        (result) => {
          this.task = result;
          console.log(result);
          this.setStatusColor();
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

  openAttachLinkDialog() {
    const dialogRef = this.dialog.open(AddLinkDialogComponent, {restoreFocus: false});
    dialogRef.afterClosed().subscribe(() => this.attachmentTrigger.focus());
  }

  submitTask() {
    this.taskService.SubmitStudentTask([],this.task.studentTaskId).subscribe(
      res => console.log("Return data: " + res)
    );
  }

  remove(attachment: StudentTaskAttachment): void {
    const index = this.task.attachments.indexOf(attachment);

    if (index >= 0) {
      this.task.attachments.splice(index, 1);
    }
  }

}
