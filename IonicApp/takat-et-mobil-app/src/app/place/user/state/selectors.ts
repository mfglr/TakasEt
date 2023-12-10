import { createFeatureSelector, createSelector } from "@ngrx/store";
import { State } from "./reducer";

const selectStore = createFeatureSelector<State>("UserPageStore");
export const selectUserPageState = (props : {userId : number}) => createSelector(
  selectStore,
  state => state.entities[props.userId]
)
export const selectPostIds = (props : {userId : number}) => createSelector(
  selectUserPageState(props),
  state => state?.posts.postIds
);

