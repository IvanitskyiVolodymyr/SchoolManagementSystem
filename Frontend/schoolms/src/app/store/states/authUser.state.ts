import { AuthUser } from "src/app/shared/models/auth/auth-user";
import { EntityWithRole } from "src/app/shared/models/Users/entityWithRole";

export interface AuthUserState {
    authUser: AuthUser | null,
    entityWithRole: EntityWithRole | null,
    errorMessage: string | null
}