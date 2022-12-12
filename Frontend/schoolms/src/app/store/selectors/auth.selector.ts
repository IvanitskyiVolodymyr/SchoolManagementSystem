import { createFeatureSelector, createSelector } from "@ngrx/store";
import { authFeatureKey } from "../reducers/auth.reducer";
import { AuthUserState } from "../states/authUser.state";

export const featureSelector = createFeatureSelector<AuthUserState>(authFeatureKey);
export const userSelector = createSelector(featureSelector, state => state.user);
export const entityWithRole = createSelector(featureSelector, state => state.entityWithRole);
export const tokensSelector = createSelector(featureSelector, state => state.tokens);
export const authErrorSelector = createSelector(featureSelector, state => state.errorMessage);