import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProfileFollowingPageState } from "./reducer";

const selectStore = createFeatureSelector<ProfileFollowingPageState>("ProfileFollowingPageStore")
export const selectActiveIndex = createSelector(selectStore,state => state.activeIndex)
