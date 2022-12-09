import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentsRoutingModule } from './students-routing.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { StudentBaseComponent } from './components/student-base/student-base.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    NavbarComponent,
    StudentBaseComponent
  ],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    SharedModule
  ]
})
export class StudentsModule { }
