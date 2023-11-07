import { createFeatureSelector, createSelector } from "@ngrx/store";
import { initialPageOfComments } from "../app-states";
import { CommentResponse } from "src/app/models/responses/comment-response";
import { AppChildCommentState, ChildState, childAdapter, commentsOfCommentQueryId } from "./state";

const selectAppCommentState = createFeatureSelector<AppChildCommentState>("AppChildCommentState");
const selectParentState = createSelector(selectAppCommentState,state => state.parentState);

const selectChildState = (props : {parentComment : CommentResponse}) => createSelector(
    selectParentState,
    (state) : ChildState => {
        let queryId = commentsOfCommentQueryId + props.parentComment.id;
        if(state.entities[queryId])
            return state.entities[queryId]!
        return childAdapter.getInitialState({
            queryId : queryId,
            page : {...initialPageOfComments},
            status : false,
            displayedCount : 0,
            visibility : true,
            remainingCount : props.parentComment.countOfChildren
        })
    }
)
export const selectResponses = (props : {parentComment : CommentResponse}) => createSelector(
    selectChildState(props),
    childAdapter.getSelectors().selectAll
)
export const selectRemainingCount = (props : {parentComment : CommentResponse}) => createSelector(
    selectChildState(props),
    state => state.remainingCount
)
export const selectDisplayedCount = (props : {parentComment : CommentResponse}) => createSelector(
    selectChildState(props),
    state => state.displayedCount
)
export const selectVisibility = (props : {parentComment : CommentResponse}) => createSelector(
    selectChildState(props),
    state => state.visibility
)
export const selectPageAndStatus = (props : {parentComment : CommentResponse}) => createSelector(
    selectChildState(props), state => ({page : state.page,status : state.status, parentComment : props.parentComment })
)
