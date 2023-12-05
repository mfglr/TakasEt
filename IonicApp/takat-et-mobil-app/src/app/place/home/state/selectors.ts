import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomePageState } from "./reducer";

const selectStore = createFeatureSelector<HomePageState>("HomePageStore");
export const selectPostIds = createSelector(selectStore,state => state.postIds);
export const selectStatusAndPage = createSelector( selectStore, state => ({ status : state.status,page : state.page }) )
