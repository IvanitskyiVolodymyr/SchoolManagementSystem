import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AuthUser } from '../models/auth/auth-user';
import { UserLogin } from '../models/Users/user-login';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private prefix: string = "/auth";
  constructor(
    private httpService: HttpClientService
  ) { }

  public login(user: UserLogin) : Observable<AuthUser> {
    return this.httpService.postFullRequest<AuthUser>(`${this.prefix}/login`, user)
    .pipe(
      map(
        (resp) => {
          return resp.body as AuthUser;
        })
    );
  }
}