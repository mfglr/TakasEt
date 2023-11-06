import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as appCommentState from "./state";
import { initialPageOfComments } from "../app-states";

const selectAppCommentState = createFeatureSelector<appCommentState.AppCommentState>("AppCommentState");
const selectParentState = createSelector(selectAppCommentState,state => state.parentState);

const selectChildState = (props : {queryId : string}) => createSelector(
    selectParentState,
    (state) : appCommentState.ChildState => {
        if(state.entities[props.queryId])
            return state.entities[props.queryId]!
        return appCommentState.childAdapter.getInitialState({
            queryId : props.queryId,
            page : {...initialPageOfComments},
            status : false
        })
    }
)
const selectCommentStates = (props : {queryId : string}) => createSelector(
    selectChildState(props),
    appCommentState.childAdapter.getSelectors( (state : appCommentState.ChildState) => state ).selectAll
)
const selectCommentState = (props : {queryId : string, parentCommetId : string}) => createSelector(
    selectChildState(props),
    state => state.entities[props.parentCommetId]!
)
export const selectRemainingChildrenCount = (props : {queryId : string, parentCommetId : string}) => createSelector(
    selectCommentState(props),
    state => state.countOfRemainingChildComments
)
export const selectChildrenVisibility = (props : {queryId : string, parentCommetId : string}) => createSelector(
    selectCommentState(props),
    state => state.childrenVisibility
)
export const selectCommentResponses = (props : {queryId : string}) => createSelector(
    selectCommentStates(props),
    state => state.map(x => x.comment)
)
export const selectPageOfComments = (props : {queryId : string}) => createSelector( selectChildState(props), state => state.page )
export const selectStatusOfComments = (props : {queryId : string}) => createSelector( selectChildState(props), state => state.status )

