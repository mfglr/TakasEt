import { createFeatureSelector, createSelector } from "@ngrx/store";
import { State } from "./reducer";

const selectStore = createFeatureSelector<State>("UserPageStore");

export const selectPosts = (props : {userId : number}) => createSelector(
  selectStore,
  state => state.entities[props.userId]?.posts
)
export const selectPostIds = (props : {userId : number}) => createSelector(
  selectPosts(props),
  state => state?.entityIds
);

