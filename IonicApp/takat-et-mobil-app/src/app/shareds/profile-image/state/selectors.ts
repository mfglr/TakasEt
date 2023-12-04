import { createFeatureSelector, createSelector } from "@ngrx/store";
import { EntityProfileImageState } from "./reducer";

const selectEntityState = createFeatureSelector<EntityProfileImageState>("ProfileImageStore")
const selectState = (props : {id : number}) => createSelector(
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