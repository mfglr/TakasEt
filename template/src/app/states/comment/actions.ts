import { Update } from "@ngrx/entity";
import { createAction, props } from "@ngrx/store";
import { AddComment } from "src/app/models/requests/add-comment";
import { CommentResponse } from "src/app/models/responses/comment-response";

export const getCommentsByPostId = createAction(
  'get comments by post id',
  props<{postId : string}>()
)
export const getCommentsByPostIdSuccess = createAction(
  'get comments by post id success',
  props<{comments : CommentResponse[]}>()
)
export const getCommentWithChildren = createAction(
  'get children',
  props<{parentId : string}>()
)
export const getCommentWithChildrenSuccess = createAction(
  'get children success',
  props<{payload : CommentResponse}>()
)
export const addComment = createAction(
  "add comment",
  props<{comment : AddComment}>()
)
export const addCommentSuccess = createAction(
  "add commnent success",
  props<{comment : CommentResponse}>()
)
export const setRespondedComment = createAction(
  "set responded comment id",
  props<{comment : CommentResponse | null}>()
)
export const setParentComment = createAction(
  "set parent comment id",
  props<{comment : CommentResponse | null}>()
)
