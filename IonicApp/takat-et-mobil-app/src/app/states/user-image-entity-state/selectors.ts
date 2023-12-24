import { createFeatureSelector, createSelector } from "@ngrx/store";
import { UserImageEntityState } from "./reducer";

const selectEntityState = createFeatureSelector<UserImageEntityState>("UserImageEntityStore")
export const selectState = (props : {id : number}) => createSelector(
    selectEntityState,
    state => state.entities[props.id]
)
export const selectLoadStatus = (props : {id : number}) => createSelector(
    selectState(props),
    state => state?.loadStatus
);
export const selectUrl = (props : {id : number}) => createSelector(
    selectState(props),
    state => state?.url
);
