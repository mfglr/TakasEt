import { createAction, props } from "@ngrx/store";
import { AddComment } from "src/app/models/requests/add-comment";
import { CommentResponse } from "src/app/models/responses/comment-response";

export const addAction = createAction("[comment] addAction",props<{addComment : AddComment}>());
export const addSuccessAction = createAction("[comment] addSuccessAction",props<{payload : CommentResponse}>())
export const nextPageAction = createAction("[comment] nextPageAction",props<{postId : string}>());
export const nextPageSuccessAction = createAction(
    "[comment] nextPageSuccessAction",
    props<{payload : CommentResponse[],postId : string}>()
);