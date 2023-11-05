import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as appPostState from "./state";

const selectAppPostState = createFeatureSelector<appPostState.AppPostState>("AppPostState");
const selectParentState = createSelector(selectAppPostState,(state : appPostState.AppPostState ) => state.parentState)
const selectSelectedChildState = createSelector(
    selectAppPostState,
    (state) : appPostState.ChildState | undefined =>{
        if(state.selectedQueryId && state.parentState.entities[state.selectedQueryId])
            return state.parentState.entities[state.selectedQueryId];
        return undefined;
    }
)
const selectChildState = (props : {queryId : string}) => createSelector(selectParentState,state => state.entities[props.queryId])
export const selectPostResponses = (props : {queryId : string}) => createSelector(
    selectChildState(props),
    appPostState.childAdapter.getSelectors(
        (state : appPostState.ChildState | undefined) => {
            return state ? state : appPostState.childAdapter.getInitialState();
        }
    ).selectAll
)
export const selectPageOfPosts = (props : {queryId : string}) => createSelector( selectChildState(props), state => state?.page )
export const selectStatusOfPosts = (props : {queryId : string}) => createSelector( selectChildState(props), state => state?.status )
export const selectSelectedQueryId = createSelector( selectAppPostState,state => state.selectedQueryId )
export const selectPageOfSelectedPosts = createSelector( selectSelectedChildState, state => state?.page )
export const selectStatusOfSelectedPosts = createSelector( selectSelectedChildState, state => state?.status )