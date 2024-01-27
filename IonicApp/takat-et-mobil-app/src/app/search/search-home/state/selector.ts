import { createFeatureSelector, createSelector } from "@ngrx/store";
import { SearchHomePageState } from "./reducer";
import { appPostAdapter, appUserAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<SearchHomePageState>("SearchHomePageStore");
export const selectPosts = createSelector(selectStore,state => state.posts);
export const selectPostResponses = createSelector(selectPosts,appPostAdapter.selectResponses);
export const selectUsers = createSelector(selectStore,state => state.users);
export const selectUserResponses = createSelector(selectUsers,appUserAdapter.selectResponses);
export const selectKey = createSelector(selectStore,state => state.key);
export const selectActiveIndex = createSelector(selectStore,state=> state.activeIndex);
