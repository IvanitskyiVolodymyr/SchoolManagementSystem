import { createFeatureSelector, createSelector } from "@ngrx/store";
import { authFeatureKey } from "../reducers/auth.reducer";
import { AuthUserState } from "../states/authUser.state";

export const featureSelector = createFeatureSelector<AuthUserState>(authFeatureKey);
export const authUserSelector = createSelector(featureSelector, state => state.authUser);