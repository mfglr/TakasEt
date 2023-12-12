import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserPostsPageState } from "./reducer";

const selectStore = createFeatureSelector<UserPostsPageState>("User Posts Page Store");
export const selectUserPostsPageState = (props : {userId : number}) => createSelector(
  selectStore,
  state => state.entities[props.userId]
)
export const selectPostIds = (props : {userId : number}) => createSelector(
  selectUserPostsPageState(props),
  state => state?.postIds
)
export const selectPageAndStatus = (props : {userId : number}) => createSelector(
  selectUserPostsPageState(props),
  state => ({ page : state?.page,status : state?.status})
)
