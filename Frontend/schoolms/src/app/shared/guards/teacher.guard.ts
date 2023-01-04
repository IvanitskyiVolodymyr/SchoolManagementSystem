import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppRoute } from 'src/app/AppRoute';
import { userSelector } from 'src/app/store/selectors/auth.selector';
import { Role } from '../models/role/role';

@Injectable({
  providedIn: 'root'
})
export class TeacherGuard implements CanActivate {

  constructor(private store: Store,
    private router: Router) { }
  canActivate(
 ):  boolean {
  this.store.select(userSelector).subscribe(
    (user) => {
      debugger
      if(user)
      {
        switch(user.roleId) {
          case Role.Teacher : {
            return true;
          }
          case Role.Parent : {
            this.router.navigate([`/${AppRoute.Parent}`]);
            return false;
          }
          case Role.Student : {
            this.router.navigate([`/${AppRoute.Student}`]);
            return false;
          }
        }
      }
      return false;
    }
  )
    return false;
  }
  
}
