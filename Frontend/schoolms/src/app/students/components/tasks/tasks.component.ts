import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
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

  public allTasks: Array<ResponseTaskWithGrade> = [] as Array<ResponseTaskWithGrade>;
  tasksFilter = this.formBuilder.group({
    isNotDone: true,
    isWaitForCheck: false,
    isChecked: false,
    isHomeWork: true,
    isControlWork: true,
    isClassWork: true,
    isAdditionalWork: true
  });

  public tasksByDay: Array<TasksDay> = [];

  public filteredTasks: Array<TasksDay> = [];


  constructor(private taskService: TasksService,
    private store: Store,
    private formBuilder: FormBuilder) { }

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

  public onDateRangeChanged(date: DateRange) {
    this.taskService.GetAllTasksWithGradesForStudent(this.studentId, date.startDate, date.endDate)
    .subscribe(
      (result) => {
        this.allTasks = result;

        this.filterTasks();
      }
    );
  }

  public filterTasks() {
    let tasksBuffer = [] as Array<ResponseTaskWithGrade>;
    if(this.tasksFilter.controls.isNotDone.value) {
      tasksBuffer = this.allTasks.filter(t => t.isDone === false);
    }
    if(this.tasksFilter.controls.isWaitForCheck.value) {
      tasksBuffer = [...tasksBuffer].concat(this.allTasks.filter(t => t.isDone === true && t.isChecked == false));
    }
    if(this.tasksFilter.controls.isChecked.value) {
      tasksBuffer = [...tasksBuffer].concat(this.allTasks.filter(t => t.isDone === true && t.isChecked == true));
    }

    const filteredByType = this.filterByType();

    tasksBuffer = tasksBuffer.filter(value => filteredByType.includes(value));

    this.filteredTasks = this.groupTasksByDays(tasksBuffer);
  }

  private filterByType() {
    let tasksBuffer = [] as Array<ResponseTaskWithGrade>;

    if(this.tasksFilter.controls.isHomeWork.value) {
      tasksBuffer = [...tasksBuffer].concat(this.allTasks.filter(t => t.taskType === TaskType.HomeWork));
    }
    if(this.tasksFilter.controls.isControlWork.value) {
      tasksBuffer = [...tasksBuffer].concat(this.allTasks.filter(t => t.taskType === TaskType.ControlWork));
    }
    if(this.tasksFilter.controls.isClassWork.value) {
      tasksBuffer = [...tasksBuffer].concat(this.allTasks.filter(t => t.taskType === TaskType.ClassWork));
    }
    if(this.tasksFilter.controls.isAdditionalWork.value) {
      tasksBuffer = [...tasksBuffer].concat(this.allTasks.filter(t => t.taskType === TaskType.AdditionalWork));
    }

    return tasksBuffer;
  }
}
