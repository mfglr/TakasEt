import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageOfPosts = createAction("next page of posts")
export const nextPageOfPostsSuccess = createAction("next page of posts success",props<{posts : PostResponse[]}>())

export const loadImage = createAction("loadPostImage",props<{ postId : number,index : number}>())
export const loadImageSuccess = createAction("loadImageSuccess",props<{ postId : number, index : number,url : string }>())
export const setCurrentIndex = createAction("setCurrentIndex",props<{postId : number,index : number}>())