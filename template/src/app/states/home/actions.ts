import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageOfPosts = createAction( "next page of posts" );
export const nextPageOfPostsSuccess = createAction( "next page of posts success",props<{posts : PostResponse[]}>() );
export const setPageOfPosts = createAction("set page of posts");
export const resetPageOfPosts = createAction("reset page of posts");
export const setStatusOfPosts = createAction("set status of posts",props<{count : number}>());
export const setSelectedPostId = createAction("set selected post",props<{postId : string}>());
