import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProfilePageState } from "./reducer";

const selectStore = createFeatureSelector<ProfilePageState>("ProfilePageStore");
export const selectPostIds = createSelector(selectStore,state => state.postIds);
export const selectStatusAndPage = createSelector( selectStore, state => ({ status : state.status,page : state.page }) )
export const selectActiveTab = createSelector(selectStore,state => state.activeTab)