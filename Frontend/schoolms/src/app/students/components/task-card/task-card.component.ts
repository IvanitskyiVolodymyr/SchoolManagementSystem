import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { ResponseTaskWithGrade } from 'src/app/shared/models/tasks/responseTaskWithGrade';
import { selectStudentTaskAttachments } from 'src/app/store/selectors/user.selector';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.scss']
})
export class TaskCardComponent implements OnInit{

  @Input() task: ResponseTaskWithGrade = {} as ResponseTaskWithGrade;
  public draftAttachments = 0;

  constructor(private router: Router,
    private store: Store) { }

  public statusBgColor = '#E4F6D0';

  ngOnInit(): void {
    this.setStatusColor();
    this.getStudentTaskAttachmentFromStorage(this.task.studentTaskId);
  }

  private setStatusColor() {
    if(this.task.isChecked) {
      this.statusBgColor = '#80BBA0';
    }
    else {
      if(this.task.isDone) {
        this.statusBgColor = '#DEAE77';
      } else {
        this.statusBgColor = '#DE0000';
      }
    }
  }

  public taskClick() {
    this.router.navigate(['/student/tasks/',this.task.studentTaskId]);
  }

  private getStudentTaskAttachmentFromStorage(studentTaskId: number) {
    this.store.select(selectStudentTaskAttachments(studentTaskId)).subscribe(
      result => {
        if(result.length > 0 && result[0]?.attachments.length > 0) {
          this.draftAttachments = result[0].attachments.length;
        }
      }
    );
  }
}
