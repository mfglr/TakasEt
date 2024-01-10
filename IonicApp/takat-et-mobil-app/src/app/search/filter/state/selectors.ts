import { createFeatureSelector, createSelector } from "@ngrx/store";
import { FilterPostsPageState } from "./reducer";

const selectStore = createFeatureSelector<FilterPostsPageState>("FilterPostPageStore");
export const selectKey = createSelector(selectStore,state => state.key);
export const selectCategoryIds = createSelector(selectStore,state => state.categoryIds);
export const selectPosts = createSelector(selectStore,state => state.posts);
export const selectPostIds = createSelector(selectPosts,state => state.entityIds);
