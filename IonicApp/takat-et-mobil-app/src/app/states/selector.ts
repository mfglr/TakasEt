import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppState } from "./reducer";
import { appPostAdapter } from "./app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<AppState>("AppStore")
const selectProfileState = createSelector(selectStore,state => state.profileState)
export const selectPosts = createSelector(selectProfileState,state => state.posts)
export const selectPostResponses = createSelector(selectPosts,appPostAdapter.selectResponses)

const selectLoginState = createSelector(selectStore,state => state.loginState)
export const selectLoginResponse = createSelector(selectLoginState,state => state.loginResponse)
export const selectUserId = createSelector(selectLoginResponse,state => state?.userId)
