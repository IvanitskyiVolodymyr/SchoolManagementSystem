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
  let result = false;
  this.store.select(userSelector).subscribe(
    (user) => {
      if(user)
      {
        switch(user.roleId) {
          case Role.Teacher : {
            result = true;
            break;
          }
          case Role.Parent : {
            this.router.navigate([`/${AppRoute.Parent}`]);
            result = false;
            break;
          }
          case Role.Student : {
            this.router.navigate([`/${AppRoute.Student}`]);
            result = false;
            break;
          }
        }
      }
    }
  )
    return result;
  }
  
}
