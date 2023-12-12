import { createFeatureSelector, createSelector } from "@ngrx/store";
import { State } from "./reducer";

const selectStore = createFeatureSelector<State>("ExplorePagesStore");
export const selectExplorePageState = (props : {postId : number}) => createSelector(
  selectStore,
  state => state.entities[props.postId]
)
export const selectPostIds = (props : {postId : number}) => createSelector(
  selectExplorePageState(props),
  state => state?.posts.entityIds
);

