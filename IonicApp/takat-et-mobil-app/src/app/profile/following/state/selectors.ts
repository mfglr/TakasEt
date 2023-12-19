import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProfileFollowingPageState } from "./reducer";

const selectStore = createFeatureSelector<ProfileFollowingPageState>("ProfileFollowingPageStore")
export const selectActiveTab = createSelector(selectStore,state => state.activeTab)
