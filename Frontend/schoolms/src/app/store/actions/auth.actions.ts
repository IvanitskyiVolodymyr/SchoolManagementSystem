import { createAction, props } from "@ngrx/store";
import { AuthUser } from "src/app/shared/models/auth/auth-user";
import { Token } from "src/app/shared/models/auth/token";
import { UserLogin } from "src/app/shared/models/Users/user-login";

export const loginAction = createAction(
    '[Auth] Login',
    props<{userLogin: UserLogin}>()
);

export const loginSuccessAction = createAction(
    '[Auth] Login success',
    props<{userAuth: AuthUser}>()
);

export const loginFailureAction = createAction(
    '[Auth] Login failure',
    props<{error: any}>()
);

export const logoutAction = createAction(
    '[Auth] Logout'
);

export const refreshAction = createAction(
    '[Auth] Refresh',
    props<{tokens: Token}>()
);