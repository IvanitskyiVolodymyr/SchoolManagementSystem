import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotAcceptableComponent } from '../shared/components/errors/not-acceptable/not-acceptable.component';
import { ScheduleListComponent } from '../shared/components/schedule/schedule-list/schedule-list.component';
import { JournalComponent } from './components/journal/journal.component';
import { StudentBaseComponent } from './components/student-base/student-base.component';
import { TaskInfoComponent } from './components/task-info/task-info.component';
import { TasksComponent } from './components/tasks/tasks.component';

const studentRoutes: Routes = [
  {
    path: 'student', component: StudentBaseComponent,
    children: [
      {
        path: 'schedule', component: ScheduleListComponent
      },
      {
        path: 'tasks', component: TasksComponent
      },
      {
        path: 'tasks/:id', component: TaskInfoComponent
      },
      {
        path: 'journal', component: JournalComponent
      },
      {
        path: '', redirectTo:'schedule', pathMatch: 'full'
      },
      { path: 'not-acceptable', component: NotAcceptableComponent }
    ],
  },
  {
    path: '', redirectTo:'student', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(studentRoutes)],
  exports: [RouterModule]
})
export class StudentsRoutingModule { }
