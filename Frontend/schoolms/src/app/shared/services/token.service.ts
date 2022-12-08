import { Injectable } from '@angular/core';
import { Token } from '../models/auth/token';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  public saveTokens(tokens: Token) {
    localStorage.setItem('access-token', tokens.accessToken);
    localStorage.setItem('refresh-token', tokens.refreshToken);
  }

  public removeTokensFromStorage() {
    localStorage.removeItem('access-token');
    localStorage.removeItem('refresh-token');
  }

  public getAccessToken() : string | null {
    const data = localStorage.getItem('access-token');
    return !data ? null : data;
  }

  public getRefreshToken() : string | null {
    const data = localStorage.getItem('refresh-token');
    return !data ? null : data;
  }
}
