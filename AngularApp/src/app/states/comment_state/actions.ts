import { createAction, props } from "@ngrx/store";
import { CommentResponse } from "src/app/models/responses/comment-response";

export const nextPageOfComments = createAction("nextPageOfComments",props<{postId : string,queryId : string}>());
export const nextPageOfCommentsSuccess = createAction("nextPageSuccess",props<{payload : CommentResponse[],queryId : string}>());
export const nextPageOfChildren = createAction("nextPageOfChildren",props<{commentId : string,queryId : string}>());
