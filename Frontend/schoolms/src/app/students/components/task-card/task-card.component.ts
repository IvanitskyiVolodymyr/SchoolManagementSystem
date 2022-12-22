import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ResponseTaskWithGrade } from 'src/app/shared/models/tasks/responseTaskWithGrade';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.scss']
})
export class TaskCardComponent implements OnInit{

  @Input() task: ResponseTaskWithGrade = {} as ResponseTaskWithGrade;

  constructor(private router: Router) { }

  public statusBgColor = '#E4F6D0';

  ngOnInit(): void {
    this.setStatusColor();
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
}
