import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeacherRoutingModule } from './teacher-routing.module';
import { TeacherBaseComponent } from './components/teacher-base/teacher-base.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    TeacherBaseComponent
  ],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    SharedModule
  ]
})
export class TeacherModule { }
