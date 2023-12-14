import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProfilePageState } from "./reducer";

const selectStore = createFeatureSelector<ProfilePageState>("ProfilePageStore");
export const selectActiveTab = createSelector(selectStore,state => state.activeTab)
