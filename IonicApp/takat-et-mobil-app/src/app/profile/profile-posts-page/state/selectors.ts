import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProfilePostsPageState } from "./reducer";

const selectStore = createFeatureSelector<ProfilePostsPageState>("ProfilePostsPageStore");
export const selectStartPostId = createSelector(
  selectStore,
  state => state.startPostId
);
