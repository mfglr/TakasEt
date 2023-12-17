import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserEntityState } from "./reducer";

const selectStore = createFeatureSelector<UserEntityState>("UserEntityStore");
export const selectUserState = (props : {userId : number}) => createSelector(
  selectStore,state => state.entities[props.userId]
)
export const selectUser = (props : {userId : number}) => createSelector(
  selectUserState(props),state => state?.user
)
