import { Pipe, PipeTransform } from '@angular/core';
import { TaskType } from '../models/tasks/taskType';

@Pipe({
  name: 'taskType'
})
export class TaskTypePipe implements PipeTransform {

  transform(taskType: TaskType): string {
    let taskName = "";
    switch(taskType) {
      case TaskType.HomeWork : {
        taskName = "Домашка";
        break;
      }
      case TaskType.ControlWork : {
        taskName = "Контрольна робота";
        break;
      }
      case TaskType.AdditionalWork : {
        taskName = "Індивідувальне завдання";
        break;
      }
    }
    return taskName;
  }

}
