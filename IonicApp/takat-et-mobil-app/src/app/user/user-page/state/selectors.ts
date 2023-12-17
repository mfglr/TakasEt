import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserPageCollectionState } from "./reducer";

const selectStore = createFeatureSelector<UserPageCollectionState>("UserPageCollectionStore");
export const selectUserPageState = (props : {userId : number}) => createSelector(
  selectStore,
  state => state.entities[props.userId]
)
export const selectActiveTab = (props : {userId : number}) => createSelector(
  selectUserPageState(props),
  state => state?.activeTab
)

