import { createReducer, on } from "@ngrx/store";
import { AuthUser } from "src/app/shared/models/auth/auth-user";
import { AuthUserState } from "../states/authUser.state";
import * as AuthActions from "../actions/auth.actions"

export const initAuthUserState: AuthUserState = {
    authUser: {} as AuthUser,
};
export const authReducer = createReducer(
    initAuthUserState,
    on(AuthActions.loginSuccessAction, (state, action) => ({
        ...state,
        authUser: action.userAuth
    }))
    
);

export const authFeatureKey = 'auth';