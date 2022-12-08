import { createReducer, on } from "@ngrx/store";
import { AuthUserState } from "../states/authUser.state";
import * as AuthActions from "../actions/auth.actions"
import * as UserActions from "../actions/user.actions";

export const initAuthUserState: AuthUserState = {
    //authUser: null,
    user: null,
    tokens: null,
    entityWithRole: null,
    errorMessage: null
};
export const authReducer = createReducer(
    initAuthUserState,
    on(AuthActions.loginSuccessAction, (state, action) => ({
        ...state,
        user: action.userAuth.user,
        tokens: action.userAuth.tokens
    })),
    on(AuthActions.loginFailureAction, (state, action) => ({
        ...state,
        errorMessage: action.error
    })),
    on(UserActions.getEntityIdWithRole, (state, action) => ({
        ...state,
        entityWithRole: action.entityWithRole
    })),
    on(UserActions.getEntityIdWithRoleFailure, (state, action) => ({
        ...state,
        errorMessage: action.error
    })),
    on(AuthActions.logoutAction, (state) => ({
        ...state,
        tokens: null,
        user: null,
        entityWithRole: null,
        errorMessage: null
    })),
    on(AuthActions.refreshAction, (state, action) => ({
        ...state,
        tokens: action.tokens
    }))
    
);

export const authFeatureKey = 'auth';