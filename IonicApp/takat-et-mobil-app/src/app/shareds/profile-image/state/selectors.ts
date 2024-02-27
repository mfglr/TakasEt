import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserImageEntityState } from "./reducer";

const selectStore = createFeatureSelector<UserImageEntityState>("UserImageStore");
export const selectState = (props : {id : string}) => createSelector(selectStore,state => state.entities[props.id]);
export const selectUrl = (props : {id : string}) => createSelector( selectState(props), state => state?.url );
