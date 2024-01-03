import { createFeatureSelector, createSelector } from "@ngrx/store";
import { SearchHomePageState } from "./reducer";

const selectStore = createFeatureSelector<SearchHomePageState>("SearchHomePageStore");
export const selectPosts = createSelector(selectStore,state => state.posts);
export const selectPostIds = createSelector(selectPosts,state => state.entityIds);
export const selectUsers = createSelector(selectStore,state => state.users);
export const selectUserIds = createSelector(selectUsers,state => state.entityIds);
export const selectKey = createSelector(selectStore,state => state.key);
export const selectActiveIndex = createSelector(selectStore,state=> state.activeIndex);
