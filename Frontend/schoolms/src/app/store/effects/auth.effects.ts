import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, map, of, tap } from "rxjs";
import { AuthService } from "src/app/shared/services/auth.service";
import * as AuthActions from "../actions/auth.actions";

@Injectable()
export class AuthEffects {
  
    login$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.loginAction),
      exhaustMap(action =>
        this.authService.login(action.userLogin).pipe(
          map(userAuth => AuthActions.loginSuccessAction({ userAuth })),
          catchError(error => of(AuthActions.loginFailureAction({ error })))
        )
      )
    )
  );

    loginSucces$ = createEffect(() => 
    this.actions$.pipe(
      ofType(AuthActions.loginSuccessAction),
      tap((action)=>{
        localStorage.setItem('access-token', action.userAuth.tokens.accessToken);
        localStorage.setItem('refresh-token', action.userAuth.tokens.refreshToken);
        this.router.navigateByUrl('/');
        })
      ), { dispatch: false }
    );

    constructor(
        private actions$: Actions,
        private authService: AuthService,
        private router: Router
    ) { }
}