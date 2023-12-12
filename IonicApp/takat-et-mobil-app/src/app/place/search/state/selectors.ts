import { createFeatureSelector, createSelector } from "@ngrx/store";
import { SearchPageState } from "./reducer";

const selectStore = createFeatureSelector<SearchPageState>("SearchPageStore");
export const selectPostIds = createSelector(selectStore,state => state.posts.entityIds);
export const selectStatusAndPage = createSelector(
  selectStore,
  state => ({
    status : state.posts.isLastEntities,
    page : state.posts.page
  })
)
