import { createFeatureSelector, createSelector } from "@ngrx/store";
import { State } from "./reducer";

const selectStore = createFeatureSelector<State>("PostImageStore");

export const selectPostImageState = (props : { id : number} ) => createSelector(
    selectStore,
    state => state.entities[props.id]
)
export const selectUrl = (props : {id : number}) => createSelector(
    selectPostImageState(props),
    state => state?.url
)
export const selectLoadStatus = (props : {id : number} ) => createSelector(
    selectPostImageState(props),
    state => state?.loadStatus
)
