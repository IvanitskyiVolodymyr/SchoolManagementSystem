import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeacherRoutingModule } from './teacher-routing.module';
import { TeacherBaseComponent } from './components/teacher-base/teacher-base.component';
import { SharedModule } from '../shared/shared.module';
import { TeacherScheduleBaseComponent } from './components/teacher-schedule-base/teacher-schedule-base.component';


@NgModule({
  declarations: [
    TeacherBaseComponent,
    TeacherScheduleBaseComponent
  ],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    SharedModule
  ]
})
export class TeacherModule { }
