import { createFeatureSelector, createSelector } from "@ngrx/store";
import { SearchHomePageState } from "./reducer";

const selectStore = createFeatureSelector<SearchHomePageState>("SearchHomePageStore");
export const selectPosts = createSelector(selectStore,state => state.posts);
export const selectPostIds = createSelector(selectPosts,state => state.entityIds);
export const selectKey = createSelector(selectStore,state => state.key);
