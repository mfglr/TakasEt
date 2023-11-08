import { createAction, props } from "@ngrx/store";
import { CommentResponse } from "src/app/models/responses/comment-response";

export const setAction = createAction(
    "[replied_comment_state] setAction",
    props<{userName : string,comment: CommentResponse,parentComment : CommentResponse | undefined}>()
);
export const resetAction = createAction("[replied_comment_state] resetAction")