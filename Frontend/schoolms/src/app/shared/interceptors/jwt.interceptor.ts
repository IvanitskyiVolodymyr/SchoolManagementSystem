import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { BehaviorSubject, catchError, filter, Observable, switchMap, take, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Token } from '../models/auth/token';
import { TokenService } from '../services/token.service';
import { Store } from '@ngrx/store';
import { logoutAction, refreshAction } from 'src/app/store/actions/auth.actions';
import { AuthUser } from '../models/auth/auth-user';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  private isRefreshing = false;
  private refreshTokenSubject = new BehaviorSubject<Token | null>(null);
  
  constructor(
    private authService: AuthService,
    private tokenService: TokenService,
    private store: Store
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token: string = this.tokenService.getAccessToken() as string;
    let authRequest = request;
    if (token != null) {
      authRequest = this.addTokenHeader(request, token);
    }
    return next.handle(authRequest).pipe(
      catchError(error => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          return this.handle401Error(authRequest, next);
        }
  
        return throwError(error);
      })
    );
  }

  // eslint-disable-next-line
  private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      const refreshtoken = this.tokenService.getRefreshToken() as string;
      const accessToken = this.tokenService.getAccessToken() as string;

      const tokens: Token = { accessToken: accessToken, refreshToken: refreshtoken} as Token

      if (tokens)
        return this.authService.refreshToken(tokens).pipe(
          switchMap((authUser: AuthUser) => {
            const tokens = authUser.tokens;
            this.store.dispatch(refreshAction({tokens}));
            this.isRefreshing = false;
            this.tokenService.saveTokens(authUser.tokens);
            this.refreshTokenSubject.next(authUser.tokens);
            
            return next.handle(this.addTokenHeader(request, authUser.tokens.accessToken));
          }),
          catchError((err) => {
            this.isRefreshing = false;
            
            this.store.dispatch(logoutAction());
            return throwError(err);
          })
        );
    }

    return this.refreshTokenSubject.pipe(
      filter(token => token !== null),
      take(1),
      switchMap((token) => next.handle(this.addTokenHeader(request, token?.accessToken as string)))
    );
  }

  // eslint-disable-next-line
  private addTokenHeader(request: HttpRequest<any>, token: string) {
    return request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
  }
}
