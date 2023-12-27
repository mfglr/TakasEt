import { createFeatureSelector, createSelector } from "@ngrx/store";
import { SearchHomePageState } from "./reducer";

const selectStore = createFeatureSelector<SearchHomePageState>("SearchHomePageStore");
export const selectAbstarctPosts = createSelector(selectStore,state => state.abstractPosts);
export const selectAbstractPostIds = createSelector(selectAbstarctPosts,state => state.entityIds);
