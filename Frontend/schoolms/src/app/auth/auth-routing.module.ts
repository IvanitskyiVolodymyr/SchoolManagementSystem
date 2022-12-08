import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogInGuard } from '../shared/guards/log-in.guard';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [LogInGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
