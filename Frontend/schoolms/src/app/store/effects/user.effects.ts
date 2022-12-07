import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, exhaustMap, map, of } from "rxjs";
import { UserService } from "src/app/shared/services/user.service";
import * as AuthActions from "../actions/auth.actions";
import * as UserActions from "../actions/user.actions";

@Injectable()
export class UserEffects {
    constructor(
        private actions$: Actions,
        private userService: UserService
    ) { }

    $entityWithRole = createEffect(() => 
        this.actions$.pipe(
            ofType(AuthActions.loginSuccessAction),
            exhaustMap(action => {
                return this.userService.getEntityIdWithRole(action.userAuth.user.userId, action.userAuth.user.roleId).pipe(
                    map(entityWithRole => UserActions.getEntityIdWithRole({entityWithRole})),
                    catchError(error => of(UserActions.getEntityIdWithRoleFailure({error})))
                );
            }
            )
        )
    );
}