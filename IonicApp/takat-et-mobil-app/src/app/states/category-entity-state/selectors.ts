import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CategoryEntityState, selectAll } from "./reducer";

const selectStore = createFeatureSelector<CategoryEntityState>("CategoryEntityStore");
export const selectPageAndStatus = createSelector(
  selectStore,
  state => ({isLastEntities : state.isLastEntities,page : state.page})
)
export const selectCategories = createSelector(selectStore,state => selectAll(state))
