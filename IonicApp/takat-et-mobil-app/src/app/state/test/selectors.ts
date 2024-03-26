import { createFeatureSelector, createSelector } from "@ngrx/store";
import { TestState, pipeAdapter } from "./reducer";

export const selectStore = createFeatureSelector<TestState>("TestStore")
export const selectData = createSelector(
  selectStore,
  state => pipeAdapter.getSelectors().selectAll(state.pipe)
);
