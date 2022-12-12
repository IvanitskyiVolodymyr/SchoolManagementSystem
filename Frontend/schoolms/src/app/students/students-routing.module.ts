import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ScheduleListComponent } from '../shared/components/schedule/schedule-list/schedule-list.component';
import { StudentBaseComponent } from './components/student-base/student-base.component';

const studentRoutes: Routes = [
  {
    path: 'student', component: StudentBaseComponent,
    children: [
      {
        path: 'schedule', component: ScheduleListComponent
      },
      {
        path: '', redirectTo:'schedule', pathMatch: 'full'
      }
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
