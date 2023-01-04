import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotAcceptableComponent } from '../shared/components/errors/not-acceptable/not-acceptable.component';
import { TeacherBaseComponent } from './components/teacher-base/teacher-base.component';

const teacherRoutes: Routes = [
  {
    path: '', component: TeacherBaseComponent,
    children: [

      { path: 'not-acceptable', component: NotAcceptableComponent }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(teacherRoutes)],
  exports: [RouterModule]
})
export class TeacherRoutingModule { }
