import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentsRoutingModule } from './students-routing.module';
import { StudentBaseComponent } from './components/student-base/student-base.component';
import { SharedModule } from '../shared/shared.module';
import { TasksComponent } from './components/tasks/tasks.component';
import { TaskCardComponent } from './components/task-card/task-card.component';
import { TaskInfoComponent } from './components/task-info/task-info.component';
import { JournalComponent } from './components/journal/journal.component';
import { CommentCardComponent } from './components/comment-card/comment-card.component';
import { CommentFormComponent } from './components/comment-form/comment-form.component';
import { CommentsComponent } from './components/comments/comments.component';


@NgModule({
  declarations: [
    StudentBaseComponent,
    TasksComponent,
    TaskCardComponent,
    TaskInfoComponent,
    JournalComponent,
    CommentCardComponent,
    CommentFormComponent,
    CommentsComponent
  ],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    SharedModule,
  ]
})
export class StudentsModule { }
