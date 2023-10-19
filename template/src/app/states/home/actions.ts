import { createAction, props } from "@ngrx/store";
import { CommentResponse } from "src/app/models/responses/comment-response";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageOfPosts = createAction( "next page of posts" );
export const nextPageOfPostsSuccess = createAction( "next page of posts success",props<{posts : PostResponse[]}>() );
export const setPageOfPosts = createAction("set page of posts");
export const resetPageOfPosts = createAction("reset page of posts");
export const setStatusOfPosts = createAction("set status of posts",props<{count : number}>());
export const setSelectedPostId = createAction("set selected post",props<{postId : string}>());

export const nextPageOfComments = createAction("next page of comments");
export const nextPageOfCommentsSuccess = createAction("next page of comments success",props<{comments : CommentResponse[]}>());
export const setPageOfComments = createAction("set page of comments");
export const setStatusOfComments = createAction("set status of comments",props<{count : number}>())
