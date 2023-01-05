import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotAcceptableComponent } from '../shared/components/errors/not-acceptable/not-acceptable.component';
import { TeacherBaseComponent } from './components/teacher-base/teacher-base.component';
import { TeacherScheduleBaseComponent } from './components/teacher-schedule-base/teacher-schedule-base.component';

const teacherRoutes: Routes = [
  {
    path: '', component: TeacherBaseComponent,
    children: [
      {
        path: 'schedule', component: TeacherScheduleBaseComponent
      },
      { 
        path: 'not-acceptable', component: NotAcceptableComponent 
      },
      {
        path: '', redirectTo:'schedule', pathMatch: 'full'
      }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(teacherRoutes)],
  exports: [RouterModule]
})
export class TeacherRoutingModule { }
