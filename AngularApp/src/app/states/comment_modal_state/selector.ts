import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CommentModalState, CommentModalStateCollection, CommentState, childrenAdapter, commentModalAdapter } from "./state";
import { initialPageOfComments } from "../app-states";

const selectCommentModalStateCollection = createFeatureSelector<CommentModalStateCollection>("CommentModalStateCollection");
const selectCommentModalState = (props : {postId : string}) => createSelector(
    selectCommentModalStateCollection,
    (state) : CommentModalState =>state.entities[props.postId]!
);
export const selectCommentToReplyState = (props : {postId : string}) => createSelector(
    selectCommentModalState(props),
    state => state.commentToReplyState
)
export const selectComments = (props : {postId : string}) => createSelector(
    selectCommentModalState(props),
    state => commentModalAdapter.getSelectors().selectAll(state).map(x => x.comment)
)
export const selectStatusAndPage = (props : {postId : string}) => createSelector(
    selectCommentModalState(props),
    state => ({ status : state.status,page : state.page})
);
const selectCommentState = (props : {postId : string ,commentId : string}) => createSelector(
    selectCommentModalState(props),
    (state) : CommentState =>state.entities[props.commentId]!
)
const selectChildren = (props : {postId : string ,commentId : string}) => createSelector(
    selectCommentState(props),
    state => state.children
)
export const selectChildComments = (props : {postId : string ,commentId : string}) => createSelector(
    selectChildren(props),
    state => childrenAdapter.getSelectors().selectAll(state)
)
export const selectStatusAndPageOfChildren = (props : {postId : string ,commentId : string}) => createSelector(
    selectChildren(props),
    state => ({status : state.status,page : state.page})
)
export const selectVisibility = (props : {postId : string ,commentId : string}) => createSelector(
    selectCommentState(props),
    state => state.childrenVisibility
)
export const selectChildrenRemainingCount = (props : {postId : string ,commentId : string}) => createSelector(
    selectCommentState(props),
    state => state.remainingChildrenCount
)
export const selectDisplayedChildrenCount = (props : {postId : string ,commentId : string}) => createSelector(
    selectCommentState(props),
    state => state.displayedChildrenCount
)