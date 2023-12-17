import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserModuleCollectionState } from "./reducer";

const selectStore = createFeatureSelector<UserModuleCollectionState>("UserModuleCollectionStore");

export const selectPosts = (props : {userId : number}) =>  createSelector(
  selectStore,
  state => state.entities[props.userId]?.posts
)
export const selectPostIds = (props : {userId : number}) => createSelector(
  selectPosts(props),
  state => state?.entityIds
)
export const selectSwappedPosts = (props : {userId : number}) =>  createSelector(
  selectStore,
  state => state.entities[props.userId]?.swappedPosts
)
export const selectSwappedPostIds = (props : {userId : number}) => createSelector(
  selectSwappedPosts(props),
  state => state?.entityIds
)
export const selectNotSwappedPosts = (props : {userId : number}) =>  createSelector(
  selectStore,
  state => state.entities[props.userId]?.notSwappedPosts
)
export const selectNotSwappedPostIds = (props : {userId : number}) => createSelector(
  selectNotSwappedPosts(props),
  state => state?.entityIds
)
export const selectFollowers = (props : {userId : number}) => createSelector(
  selectStore,
  state => state.entities[props.userId]?.followers
)
export const selectFollowerIds = (props : {userId : number}) => createSelector(
  selectFollowers(props),
  state => state?.entityIds
)
export const selectFolloweds = (props : {userId : number}) => createSelector(
  selectStore,
  state => state.entities[props.userId]?.followeds
)
export const selectFollowedIds = (props : {userId : number}) => createSelector(
  selectFolloweds(props),
  state => state?.entityIds
)
