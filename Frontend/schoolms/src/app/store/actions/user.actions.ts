import { createAction, props } from "@ngrx/store";
import { EntityWithRole } from "src/app/shared/models/Users/entityWithRole";

export const getEntityIdWithRole = createAction(
    '[User] Get Entity Id with role',
    props<{entityWithRole: EntityWithRole}>()
);

export const getEntityIdWithRoleFailure = createAction(
    '[User] Entity Id with role failure',
    // eslint-disable-next-line
    props<{error: any}>()
);