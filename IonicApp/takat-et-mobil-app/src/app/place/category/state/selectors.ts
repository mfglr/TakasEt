import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CategoryPageCollectionState } from "./reducer";
import { appPostAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<CategoryPageCollectionState>("CategoryPageCollectionStore");
export const selectPosts = (props : {categoryId : number}) => createSelector(
  selectStore,state => state.entities[props.categoryId]?.posts
)
export const selectPostResponses = (props : {categoryId : number}) => createSelector(
  selectPosts(props),appPostAdapter.selectResponses
)
