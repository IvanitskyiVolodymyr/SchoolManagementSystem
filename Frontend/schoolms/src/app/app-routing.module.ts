import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './shared/guards/auth.guard';
import { TeacherGuard } from './shared/guards/teacher.guard';

const appRoutes: Routes = [
  {
    path: 'auth',
    loadChildren: () => 
      import('./auth/auth.module').then(m => m.AuthModule),
      canActivate:[AuthGuard]
  },
  {
    path: '',
    loadChildren: () => 
      import('./students/students.module').then(m => m.StudentsModule),
      canActivate: [AuthGuard]
  },
  {
    path: 'teacher',
    loadChildren: () => 
      import('./teacher/teacher.module').then(m => m.TeacherModule),
      canActivate: [AuthGuard, TeacherGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
