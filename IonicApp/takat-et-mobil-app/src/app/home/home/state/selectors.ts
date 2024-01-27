import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomePageState } from "./reducer";
import { appPostAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

const selecStore = createFeatureSelector<HomePageState>("HomePageStore");
export const selectPosts = createSelector(selecStore,state => state.posts);
export const selectIsLastEntities = createSelector(selectPosts,state => state.isLastEntities);
export const selectPostResponses = createSelector(selectPosts,state => appPostAdapter.selectResponses(state));
