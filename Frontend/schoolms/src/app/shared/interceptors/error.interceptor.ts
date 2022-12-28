import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { AppRoute } from 'src/app/AppRoute';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private router: Router
  ) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((response) => {
        if (response?.status === 406) {
          console.log(response);
    
          this.router.navigateByUrl(AppRoute.StudentNotAcceptable);
        }
        else {
          if(response.error?.message) {
            return throwError(() => { response.error.message });
          }
        }
        return throwError(() => response);
      })
    );
  }
}
