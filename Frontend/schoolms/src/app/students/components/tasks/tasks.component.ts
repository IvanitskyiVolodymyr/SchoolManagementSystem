import { Component, OnInit } from '@angular/core';
import { MatRadioChange } from '@angular/material/radio';
import { Store } from '@ngrx/store';
import { DateRange } from 'src/app/shared/models/date/date-range';
import { ResponseTaskWithGrade } from 'src/app/shared/models/tasks/responseTaskWithGrade';
import { TasksDay } from 'src/app/shared/models/tasks/tasksDay';
import { TaskType } from 'src/app/shared/models/tasks/taskType';
import { TasksService } from 'src/app/shared/services/tasks.service';
import { entityWithRole } from 'src/app/store/selectors/auth.selector';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.scss']
})
export class TasksComponent implements OnInit {
  
  public startDate: Date = new Date();
  public daysDiff = 4;
  public finishDate: Date = new Date();
  public isFromWeekBegining = false;
  public studentId = 1;

  public taskTypes = new Map<string, TaskType>(
    [
      [ "Д/З", TaskType.HomeWork ],
      [ "К/Р", TaskType.ControlWork ],
      [ "С/Р", TaskType.ClassWork ],
      [ "Індивідуальні", TaskType.AdditionalWork ],
    ]);

  public taskTypeKeys = [...this.taskTypes.keys()];

  public selectedTaskType = '';
  public selectedTaskStatus = '';

  public tasksByDay: Array<TasksDay> = [];

  public filteredTasks: Array<TasksDay> = [];


  constructor(private taskService: TasksService,
    private store: Store) { }

  ngOnInit(): void {
    this.store.select(entityWithRole).subscribe(
      result => {
        this.studentId = result?.entityId as number;
      }
    );
  }

  private groupTasksByDays(allTasks: ResponseTaskWithGrade[]) {
    this.tasksByDay = [];
    this.filteredTasks = [];
    const map = new Map<number, Array<ResponseTaskWithGrade>>();

    allTasks.forEach(task => {
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
    return this.tasksByDay;
  }

  public statusChange(event: MatRadioChange, value: string) {
    const filteredTasks = this.filterTasksByStatus(value, this.tasksByDay);
    this.filteredTasks = this.filterTasksByType(this.taskTypes.get(this.selectedTaskType), filteredTasks);
  }

  public typeChange(event: MatRadioChange, value: string) {
    const filteredTasks = this.filterTasksByType(this.taskTypes.get(value) as TaskType, this.tasksByDay);
    this.filteredTasks = this.filterTasksByStatus(this.selectedTaskStatus,filteredTasks);
  } 

  private filterTasksByStatus(value: string, tasksToFilter: TasksDay[]) {
    const bufferTasks = [] as Array<TasksDay>;

    tasksToFilter.forEach((element) => {

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
        bufferTasks.push(taskDay);
      }
    });

    return bufferTasks;
  }

  private filterTasksByType(taskType: TaskType | undefined, tasksToFilter: TasksDay[]) {
    if(taskType === undefined) {
      return tasksToFilter;
    }

    const bufferTasks = [] as Array<TasksDay>;
    tasksToFilter.forEach((element) => {
      const taskDay: TasksDay = {
        date: element.date,
        tasks: element.tasks.filter(t => t.taskType === taskType)
      };
      if(taskDay.tasks.length > 0) {
        bufferTasks.push(taskDay);
      }
    });

    return bufferTasks;
  }

  public onDateRangeChanged(date: DateRange) {
    this.taskService.GetAllTasksWithGradesForStudent(this.studentId, date.startDate, date.endDate)
    .subscribe(
      (result) => {
        const tasksByDay = this.groupTasksByDays(result);
        const filtered = this.filterTasksByStatus(this.selectedTaskStatus, tasksByDay);
        this.filteredTasks = this.filterTasksByType(this.taskTypes.get(this.selectedTaskType), filtered);
      }
    );
  }
}
