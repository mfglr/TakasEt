import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomeState, adapter } from "./reducer";

const { selectAll } = adapter.getSelectors();

const selectHomeState = createFeatureSelector<HomeState>("homeStoreSlice")

export const selectPosts = createSelector(selectHomeState,selectAll)
export const selectCurrentPageOfPosts = createSelector(selectHomeState,(state : HomeState) => state.page);
export const selectStatusOfPosts = createSelector(selectHomeState,(state : HomeState) => state.status);
export const selectSelectedPostId = createSelector(selectHomeState,(state : HomeState) => state.selectedId);
