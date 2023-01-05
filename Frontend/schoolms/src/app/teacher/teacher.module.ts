import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeacherRoutingModule } from './teacher-routing.module';
import { TeacherBaseComponent } from './components/teacher-base/teacher-base.component';
import { SharedModule } from '../shared/shared.module';
import { TeacherScheduleListComponent } from './components/teacher-schedule-list/teacher-schedule-list.component';
import { TeacherScheduleCardComponent } from './components/teacher-schedule-card/teacher-schedule-card.component';


@NgModule({
  declarations: [
    TeacherBaseComponent,
    TeacherScheduleListComponent,
    TeacherScheduleCardComponent
  ],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    SharedModule
  ]
})
export class TeacherModule { }
