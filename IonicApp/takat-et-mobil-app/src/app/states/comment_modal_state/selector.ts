import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CommentModalState, CommentModalStateCollection, CommentState, childrenAdapter, commentModalAdapter } from "./state";

const selectCommentModalStateCollection = createFeatureSelector<CommentModalStateCollection>("CommentModalStateCollection");
const selectCommentModalState = (props : {postId : number}) => createSelector(
    selectCommentModalStateCollection,
    (state) : CommentModalState =>state.entities[props.postId]!
);
export const selectCommentToReplyState = (props : {postId : number}) => createSelector(
    selectCommentModalState(props),
    state => state.commentToReplyState
)
export const selectComments = (props : {postId : number}) => createSelector(
    selectCommentModalState(props),
    state => commentModalAdapter.getSelectors().selectAll(state).map(x => x.comment)
)
export const selectStatusAndPage = (props : {postId : number}) => createSelector(
    selectCommentModalState(props),
    state => ({ status : state.status,page : state.page})
);
const selectCommentState = (props : {postId : number ,commentId : number}) => createSelector(
    selectCommentModalState(props),
    (state) : CommentState =>state.entities[props.commentId]!
)
const selectChildren = (props : {postId : number ,commentId : number}) => createSelector(
    selectCommentState(props),
    state => state.children
)
export const selectChildComments = (props : {postId : number ,commentId : number}) => createSelector(
    selectChildren(props),
    state => childrenAdapter.getSelectors().selectAll(state)
)
export const selectStatusAndPageOfChildren = (props : {postId : number ,commentId : number}) => createSelector(
    selectChildren(props),
    state => ({status : state.status,page : state.page})
)
export const selectVisibility = (props : {postId : number ,commentId : number}) => createSelector(
    selectCommentState(props),
    state => state.childrenVisibility
)
export const selectChildrenRemainingCount = (props : {postId : number ,commentId : number}) => createSelector(
    selectCommentState(props),
    state => state.remainingChildrenCount
)
export const selectDisplayedChildrenCount = (props : {postId : number ,commentId : number}) => createSelector(
    selectCommentState(props),
    state => state.displayedChildrenCount
)