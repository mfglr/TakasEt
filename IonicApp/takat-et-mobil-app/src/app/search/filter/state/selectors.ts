import { createFeatureSelector, createSelector } from "@ngrx/store";
import { FilterPostsPageState } from "./reducer";
import { appPostAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<FilterPostsPageState>("FilterPostPageStore");
export const selectKey = createSelector(selectStore,state => state.key);
export const selectCategoryIds = createSelector(selectStore,state => state.categoryIds);
export const selectPosts = createSelector(selectStore,state => state.posts);
export const selectPostResponses = createSelector(selectPosts,appPostAdapter.selectResponses);
