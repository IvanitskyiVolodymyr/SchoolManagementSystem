import { Token } from "src/app/shared/models/auth/token";
import { EntityWithRole } from "src/app/shared/models/Users/entityWithRole";
import { User } from "src/app/shared/models/Users/user";

export interface AuthUserState {
    user: User | null,
    tokens: Token | null,
    entityWithRole: EntityWithRole | null,
    errorMessage: string | null
}