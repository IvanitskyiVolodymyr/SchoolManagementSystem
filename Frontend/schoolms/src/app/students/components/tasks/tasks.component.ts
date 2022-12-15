import { Component, OnInit } from '@angular/core';
import { MatRadioChange } from '@angular/material/radio';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { DateRange } from 'src/app/shared/models/date/date-range';
import { ResponseTaskWithGrade } from 'src/app/shared/models/tasks/responseTaskWithGrade';
import { TasksDay } from 'src/app/shared/models/tasks/tasksDay';
import { TasksService } from 'src/app/shared/services/tasks.service';
import { entityWithRole } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.scss']
})
export class TasksComponent implements OnInit {
  
  public startDate: Date = new Date();
  public daysDiff: number = 4;
  public finishDate: Date = new Date();
  public isFromWeekBegining = false;
  public studentId = 1;

  public taskTypes: string[] = ['Д/З','К/Р','С/Р','Індивідувальні'];
  public selectedTaskType = '';

  public taskStatuses: string[] = ['Не здані','Здані','Перевірені'];
  public selectedTaskStatus = '';

  public tasks: ResponseTaskWithGrade[] = {} as ResponseTaskWithGrade[];
  public tasksByDay: Array<TasksDay> = [];

  public districts$: Observable<Array<TasksDay>> = {} as Observable<Array<TasksDay>>;
  public filteredTasks: Array<TasksDay> = [];
  public filter$: Observable<string> = {} as Observable<string>;



  public green = "green";

  constructor(private taskService: TasksService,
    private store: Store) { }

  ngOnInit(): void {
    this.store.select(entityWithRole).subscribe(
      result => {
        this.studentId = result?.entityId as number;
      }
    );
    console.log('status: ' + this.selectedTaskType);
  }

  private groupTasksByDays(allTasks: ResponseTaskWithGrade[]) {
    this.tasksByDay = [];
    this.filteredTasks = [];
    this.tasks = allTasks;
    const map = new Map<number, Array<ResponseTaskWithGrade>>();

    this.tasks.forEach(task => {
      const dateDay = new Date(task.endDate).getDate();

      if(!map.get(dateDay)) {
        map.set(dateDay, [])
      }
      const array = map.get(dateDay);
      array?.push(task);
    });

    map.forEach(task =>{
      const taskDay: TasksDay = {
        date: task[0].endDate,
        tasks: task.sort((b, a) => new Date(b.endDate).getTime() - new Date(a.endDate).getTime())
      };

      this.tasksByDay.push(taskDay);
    });
    this.tasksByDay = this.tasksByDay.sort((b, a) => new Date(b.date).getTime() - new Date(a.date).getTime())
    this.filteredTasks = this.tasksByDay;
    this.filterTasksByStatus(this.selectedTaskStatus);
  }

  public radioChange(event: MatRadioChange, value: string) {
    this.filterTasksByStatus(value);
  }

  private filterTasksByStatus(value: string) {
    this.filteredTasks = [];

    this.tasksByDay.forEach((element) => {

      const taskDay: TasksDay = {
        date: element.date,
        tasks: []
      };

      switch(value) {
        case "notDone": {
              taskDay.tasks = element.tasks.filter(t=> t.isDone === false);
          break;
        }
        case "done": {
            taskDay.tasks = element.tasks.filter(t => t.isDone == true && t.isChecked === false);
          break;
        }

        case "checked": {
            taskDay.tasks = element.tasks.filter(t => t.isChecked == true);
          break;
        }
        default: {
          taskDay.tasks = element.tasks;
        }
      }

      if(taskDay.tasks.length > 0) {
        this.filteredTasks.push(taskDay);
      }
    });
  }

  public onDateRangeChanged(date: DateRange) {
    this.taskService.GetAllTasksWithGradesForStudent(this.studentId, date.startDate, date.endDate)
    .subscribe(
      (result) => {
        this.groupTasksByDays(result);
      }
    );
  }
}
