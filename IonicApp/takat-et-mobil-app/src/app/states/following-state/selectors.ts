import { createFeatureSelector, createSelector } from "@ngrx/store";
import { EntityFollowingState } from "./reducer";

const selectStore = createFeatureSelector<EntityFollowingState>("EntityFollowingStore");
export const selectFollowingState = (props : {userId : number}) =>  createSelector(
  selectStore,
  state => state.entities[props.userId]
)
export const selectIsFollowed = (props : {userId : number}) =>  createSelector(
  selectFollowingState(props),
  state => state?.isFollowed
)
export const selectIsFollower = (props : {userId : number}) =>  createSelector(
  selectFollowingState(props),
  state => state?.isFollower
)
export const selectNumberOfFolloweds = (props : {userId : number}) =>  createSelector(
  selectFollowingState(props),
  state => state?.numberOfFolloweds
)
export const selectNumberOfFollowers = (props : {userId : number}) =>  createSelector(
  selectFollowingState(props),
  state => state?.numberOfFollowers
)
