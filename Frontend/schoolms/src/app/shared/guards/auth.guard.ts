import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AppRoute } from 'src/app/AppRoute';
import { TokenService } from '../services/token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(
    public tokenService: TokenService,
    public router: Router
  ) {}

  canActivate():  boolean  {
    if(!(this.tokenService.getAccessToken() && this.tokenService.getRefreshToken())) {
      this.router.navigate([`/${AppRoute.Login}`]);
      return false;
    }
    return true;
  }
}
