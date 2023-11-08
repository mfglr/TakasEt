import { createAction, props } from "@ngrx/store";
import { AddComment } from "src/app/models/requests/add-comment";
import { CommentResponse } from "src/app/models/responses/comment-response";

export const nextPageAction = createAction("[child comment] nextPageAction",props<{parentComment : CommentResponse}>())
export const nextPageActionSuccess = createAction(
    "[child comment] nextPageActionSuccess",
    props<{payload : CommentResponse[],parentComment : CommentResponse}>()
)
export const switchVisibilityAction = createAction( "[child comment] switchVisibility",props<{parentComentId : string}>())
export const setVisibileAction = createAction("[child comment] setVisibileAction",props<{parentCommentId : string}>())
export const addAction = createAction("[child comment] addAction",props<{request : AddComment,parentComment : CommentResponse}>())
export const addSuccessAction = createAction(
    "[child comment] addSuccessAction",
    props<{payload : CommentResponse,parentComment: CommentResponse}>()
)