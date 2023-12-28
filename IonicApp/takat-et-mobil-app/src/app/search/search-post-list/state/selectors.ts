import { createFeatureSelector, createSelector } from "@ngrx/store";
import { EntitySearchPostListPageState } from "./reducer";

const selectStore = createFeatureSelector<EntitySearchPostListPageState>("EntitySearchPostListPageStore");
export const selectPosts = (props : {postId : number}) => createSelector(
  selectStore,
  state => state.entities[props.postId]?.posts
)
export const selectPostIds = (props : {postId : number}) => createSelector(
  selectPosts({postId : props.postId}),
  state => state?.entityIds
)
