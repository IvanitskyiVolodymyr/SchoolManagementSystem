import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentBaseComponent } from './components/student-base/student-base.component';

const studentRoutes: Routes = [
  {
    path: '', component: StudentBaseComponent,
    /*children: [
      {
        
      }
    ]*/
  }
];

@NgModule({
  imports: [RouterModule.forChild(studentRoutes)],
  exports: [RouterModule]
})
export class StudentsRoutingModule { }
