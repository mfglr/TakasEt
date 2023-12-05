import { createFeatureSelector, createSelector } from "@ngrx/store";
import { SearchPageState } from "./reducer";

const selectStore = createFeatureSelector<SearchPageState>("SearchPageStore");
export const selectPostIds = createSelector(selectStore,state => state.postIds);
export const selectStatusAndPage = createSelector( selectStore, state => ({ status : state.status,page : state.page }) )
