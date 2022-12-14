import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, map, of, tap } from "rxjs";
import { AppRoute } from "src/app/AppRoute";
import { Role } from "src/app/shared/models/role/role";
import { AuthService } from "src/app/shared/services/auth.service";
import { TokenService } from "src/app/shared/services/token.service";
import * as AuthActions from "../actions/auth.actions";
import * as UserActions from "../actions/user.actions";

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
        this.tokenService.saveTokens(action.userAuth.tokens);
      })
      ), { dispatch: false }
    );

    redirectSucces$ = createEffect(() => 
    this.actions$.pipe(
      ofType(UserActions.getEntityIdWithRole),
      tap((action)=>{
        switch(action.entityWithRole.roleId) {
          case Role.Student as number : {
            this.router.navigate([AppRoute.Student]);
            break;
          }
          case Role.Parent as number : {
            this.router.navigate([AppRoute.Parent]);
            break;
          }
          case Role.Teacher as number : {
            this.router.navigate([AppRoute.Teacher]);
            break;
          }
        }
      })
      ), { dispatch: false }
    );

    logout$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.logoutAction),
      tap(() => {
        this.tokenService.removeTokensFromStorage();
        this.router.navigate([AppRoute.Login]);
      })
    ), { dispatch: false }
    );

    constructor(
        private actions$: Actions,
        private authService: AuthService,
        private tokenService: TokenService,
        private router: Router
    ) { }
}