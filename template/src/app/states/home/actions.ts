import { createAction, props } from "@ngrx/store";
import { CommentResponse } from "src/app/models/responses/comment-response";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageOfPosts = createAction( "next page of posts" );
export const nextPageOfPostsSuccess = createAction( "next page of posts success",props<{posts : PostResponse[]}>() );
export const setSelectedPostId = createAction("set selected post",props<{postId : string}>());
export const resetPageOfPosts = createAction("reset page of posts");

export const nextPageOfComments = createAction("next page of comments");
export const nextPageOfCommentsSuccess = createAction("next page of comments success",props<{comments : CommentResponse[]}>());
export const setSelectedCommentId = createAction("set selected comment id",props<{commentId : string}>());

export const nextPageOfChildren = createAction("next page of children");
export const nextPageOfChildrenSuccess = createAction("next page of children success",props<{comments : CommentResponse[]}>());
