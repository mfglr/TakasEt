import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserState } from "./reducer";

const selectStore = createFeatureSelector<UserState>("UserStore");
export const selectUser = (props : {userId : number}) => createSelector(selectStore,state => state.entities[props.userId])
