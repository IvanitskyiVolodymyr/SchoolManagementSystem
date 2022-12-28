import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentsRoutingModule } from './students-routing.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { StudentBaseComponent } from './components/student-base/student-base.component';
import { SharedModule } from '../shared/shared.module';
import { TasksComponent } from './components/tasks/tasks.component';
import { TaskCardComponent } from './components/task-card/task-card.component';
import { TaskInfoComponent } from './components/task-info/task-info.component';
import { JournalComponent } from './components/journal/journal.component';


@NgModule({
  declarations: [
    NavbarComponent,
    StudentBaseComponent,
    TasksComponent,
    TaskCardComponent,
    TaskInfoComponent,
    JournalComponent
  ],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    SharedModule,
  ]
})
export class StudentsModule { }
