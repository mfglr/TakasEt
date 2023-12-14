import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProfileModuleState } from "./reducer";

const selectStore = createFeatureSelector<ProfileModuleState>("ProfileModuleStore");

export const selectPosts = createSelector(selectStore,state => state.posts)
export const selectPostIds = createSelector(selectPosts,state => state?.entityIds)
export const selectSwappedPosts = createSelector(selectStore,state => state.swappedPosts)
export const selectSwappedPostIds = createSelector(selectSwappedPosts,state => state?.entityIds)
export const selectNotSwappedPosts = createSelector(selectStore,state => state.notSwappedPosts)
export const selectNotSwappedPostIds = createSelector(selectNotSwappedPosts,state => state?.entityIds)

