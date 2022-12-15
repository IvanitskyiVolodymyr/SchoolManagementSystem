import { Component, Input, OnInit } from '@angular/core';
import { ResponseTaskWithGrade } from 'src/app/shared/models/tasks/responseTaskWithGrade';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.scss']
})
export class TaskCardComponent implements OnInit{

  @Input() task: ResponseTaskWithGrade = {} as ResponseTaskWithGrade;

  public statusBgColor = '#E4F6D0';

  ngOnInit(): void {
    this.setStatusColor();
  }

  private setStatusColor() {
    if(this.task.isChecked) {
      this.statusBgColor = '#80BBA0';//'#79D879';
    }
    else {
      if(this.task.isDone) {
        this.statusBgColor = '#DEAE77';//'#F4CA16'
      } else {
        this.statusBgColor = '#B0B1B7';//'#FFB3B3'
      }

    }

  }

}
