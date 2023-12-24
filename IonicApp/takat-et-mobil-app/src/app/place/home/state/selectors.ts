import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomePageState } from "./reducer";

const selectStore = createFeatureSelector<HomePageState>("HomePageStore");
export const selectPostIds = createSelector(selectStore,state => state.posts.entityIds);
export const selectStatusAndPage = createSelector(
  selectStore, state => ({ status : state.posts.isLastEntities,page : state.posts.page })
)
export const selectIsLastEntities = createSelector(
  selectStore,
  state => state.posts.isLastEntities
)
export const selectLastRequestedPageOfPosts = createSelector(
  selectStore,
  state => state.posts.lastRequestedPage
)
