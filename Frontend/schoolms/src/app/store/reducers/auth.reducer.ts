import { createReducer, on } from "@ngrx/store";
import { AuthUser } from "src/app/shared/models/auth/auth-user";
import { AuthUserState } from "../states/authUser.state";
import * as AuthActions from "../actions/auth.actions"
import * as UserActions from "../actions/user.actions";
import { EntityWithRole } from "src/app/shared/models/Users/entityWithRole";

export const initAuthUserState: AuthUserState = {
    authUser: {} as AuthUser,
    entityWithRole: {} as EntityWithRole
};
export const authReducer = createReducer(
    initAuthUserState,
    on(AuthActions.loginSuccessAction, (state, action) => ({
        ...state,
        authUser: action.userAuth
    })),
    on(UserActions.getEntityIdWithRole, (state, action) => ({
        ...state,
        entityWithRole: action.entityWithRole
    }))
    
);

export const authFeatureKey = 'auth';