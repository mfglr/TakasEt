import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserModuleCollectionState } from "./reducer";
import { appPostAdapter, appUserAdapter } from "src/app/states/app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<UserModuleCollectionState>("UserModuleCollectionStore");

export const selectPosts = (props : {userId : number}) =>  createSelector(
  selectStore,
  state => state.entities[props.userId]?.posts
)
export const selectPostResponses = (props : {userId : number}) => createSelector(
  selectPosts(props),
  state => appPostAdapter.selectResponses(state!)
)
export const selectSwappedPosts = (props : {userId : number}) =>  createSelector(
  selectStore,
  state => state.entities[props.userId]?.swappedPosts
)
export const selectSwappedPostResponses = (props : {userId : number}) => createSelector(
  selectSwappedPosts(props),
  state => appPostAdapter.selectResponses(state!)
)
export const selectNotSwappedPosts = (props : {userId : number}) =>  createSelector(
  selectStore,
  state => state.entities[props.userId]?.notSwappedPosts
)
export const selectNotSwappedPostResponses = (props : {userId : number}) => createSelector(
  selectNotSwappedPosts(props),
  state => appPostAdapter.selectResponses(state!)
)
export const selectFollowers = (props : {userId : number}) => createSelector(
  selectStore,
  state => state.entities[props.userId]?.followers
)
export const selectFollowerResponses = (props : {userId : number}) => createSelector(
  selectFollowers(props),
  state => appUserAdapter.selectResponses(state!)
)
export const selectFolloweds = (props : {userId : number}) => createSelector(
  selectStore,
  state => state.entities[props.userId]?.followeds
)
export const selectFollowedReponses = (props : {userId : number}) => createSelector(
  selectFolloweds(props),
  state => appUserAdapter.selectResponses(state!)
)
