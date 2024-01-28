import { createFeatureSelector, createSelector } from "@ngrx/store";
import { EntitySearchPostListPageState } from "./reducer";
import { appPostAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<EntitySearchPostListPageState>("EntitySearchPostListPageStore");
export const selectPosts = (props : {postId : number}) => createSelector(
  selectStore,
  state => state.entities[props.postId]?.posts
)
export const selectPostResponses = (props : {postId : number}) => createSelector(
  selectPosts({postId : props.postId}),
  state => state != undefined ? appPostAdapter.selectResponses(state) : undefined
)
