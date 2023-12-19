import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserEntityState } from "./reducer";

const selectStore = createFeatureSelector<UserEntityState>("UserEntityStore");
export const selectUserState = (props : {userId : number}) => createSelector(
  selectStore,state => state.entities[props.userId]
)
export const selectUser = (props : {userId : number}) => createSelector(
  selectUserState(props),state => state?.user
)
export const selectNumberOfFollowers = (props : {userId : number}) => createSelector(
  selectUser(props),state => state?.countOfFollowers
)
export const selectNumberOfFolloweds = (props : {userId : number}) => createSelector(
  selectUser(props),state => state?.countOfFolloweds
)
export const selectIsFollower = (props : {userId : number}) => createSelector(
  selectUser(props),state => state?.isFollower
)
export const selectIsFollowed = (props : {userId : number}) => createSelector(
  selectUser(props),state => state?.isFollowed
)
