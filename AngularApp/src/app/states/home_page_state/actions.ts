import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageOfPosts = createAction("next page of posts")
export const nextPageOfPostsSuccess = createAction("next page of posts success",props<{posts : PostResponse[]}>())

export const loadPostImage = createAction("loadPostImage",props<{ postId : number,index : number}>())
export const loadPostImageSuccess = createAction("loadPostImageSuccess",props<{ postId : number, index : number,url : string }>())
export const setCurrentIndex = createAction("setCurrentIndex",props<{postId : number,index : number}>())

export const loadProfileImage = createAction("loadProfileImage",props<{postId : number}>())
export const loadProfileImageSuccess = createAction("loadProfileImageSuccess",props<{postId : number,url : string}>())