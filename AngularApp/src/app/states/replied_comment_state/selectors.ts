import { createFeatureSelector, createSelector } from "@ngrx/store";
import { RepliedCommentState } from "./state";

export const selectRepliedCommentState = createFeatureSelector<RepliedCommentState>("RepliedCommentState");
export const selectStatus = createSelector(selectRepliedCommentState,state => state.status);
export const selecUserName = createSelector(selectRepliedCommentState,state => state.userName);