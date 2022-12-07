import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, map, of } from "rxjs";
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

    constructor(
        private actions$: Actions,
        private authService: AuthService
    ) { }
}