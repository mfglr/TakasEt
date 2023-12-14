import { createFeatureSelector, createSelector, props } from "@ngrx/store";
import { CategoryPageCollectionState } from "./reducer";

const selectStore = createFeatureSelector<CategoryPageCollectionState>("CategoryPageCollectionStore");
export const selectPosts = (props : {categoryId : number}) => createSelector(
  selectStore,state => state.entities[props.categoryId]?.posts
)
export const selectPostIds = (props : {categoryId : number}) => createSelector(
  selectPosts(props),state => state?.entityIds
)
