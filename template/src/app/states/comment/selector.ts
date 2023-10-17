import { createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromComment from "src/app/states/comment/reducer";

const commentStore = createFeatureSelector<fromComment.CommentState>('commentStoreSlice');

export const selectComments = createSelector(commentStore,fromComment.selectComments)
export const selectCommentCount = createSelector(commentStore,fromComment.selectCommentTotal)
// export const getComments = createSelector(commentStore,state => state.comments);
// export const getChildren = createSelector(commentStore,state => state.children);
// export const getRespondedComment = createSelector(commentStore,state => state.respondedComment);
// export const getParentComment = createSelector(commentStore,state => state.parentComment);
