import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as appCommentState from "./state";
import { initialPageOfComments } from "../app-states";
import { commentsOfPostQueryId } from "./state";

const selectAppCommentState = createFeatureSelector<appCommentState.AppCommentState>("AppCommentState");
const selectParentState = createSelector(selectAppCommentState,state => state.parentState);

const selectChildState = (props : {postId : string}) => createSelector(
    selectParentState,
    (state) : appCommentState.ChildState => {
        let queryId = commentsOfPostQueryId + props.postId;
        if(state.entities[queryId])
            return state.entities[queryId]!
        return appCommentState.childAdapter.getInitialState({
            queryId : queryId,
            page : {...initialPageOfComments},
            status : false
        })
    }
)
export const selectResponses = (props : {postId : string}) => createSelector(
    selectChildState(props),
    appCommentState.childAdapter.getSelectors().selectAll
)
export const selectPageAndStatus = (props : {postId : string}) => createSelector(
    selectChildState(props),
    state => ({page : state.page,status : state.status,postId : props.postId})
)