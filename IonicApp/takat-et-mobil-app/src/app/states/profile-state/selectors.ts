import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProfileState } from "./reducer";

const selectStore = createFeatureSelector<ProfileState>("ProfileStore");

export const selectPosts = createSelector(selectStore,state => state.posts)
export const selectPostIds = createSelector(selectPosts,state => state.entityIds)

export const selectSwappedPosts = createSelector(selectStore,state => state.swappedPosts)
export const selectSwappedPostIds = createSelector(selectSwappedPosts,state => state.entityIds)

export const selectNotSwappedPosts = createSelector(selectStore,state => state.notSwappedPosts)
export const selectNotSwappedPostIds = createSelector(selectNotSwappedPosts,state => state.entityIds)

export const selectFollowers = createSelector(selectStore,state => state.followers);
export const selectFollowerIds = createSelector(selectFollowers,state => state.entityIds);

export const selectFolloweds = createSelector(selectStore,state => state.followeds);
export const selectFollowedIds = createSelector(selectFolloweds,state => state.entityIds)
