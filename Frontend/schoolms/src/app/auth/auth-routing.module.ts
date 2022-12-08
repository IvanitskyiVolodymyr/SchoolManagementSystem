import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogInGuard } from '../shared/guards/log-in.guard';
import { LoginComponent } from './login/login.component';

const authRoutes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [LogInGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(authRoutes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
