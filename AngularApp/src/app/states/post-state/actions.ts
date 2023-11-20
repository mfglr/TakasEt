import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageAction = createAction(
    "[Collection Post State] nextPageAction",
    props<{ pageId : string }>()
)
export const nextPageSuccessAction = createAction(
    "[Collection Post State] nextPageSuccessAction",
    props<{ pageId : string, payload : PostResponse[] }>()
)
export const loadPostImageAction = createAction(
    "[Collection Post State] loadPostImage",
    props<{ pageId : string, postId : number, index : number }>()
)
export const loadPostImageSuccessAction = createAction(
    "[Collection Post State] loadPostImageSuccessAction",
    props<{ pageId : string, postId : number, index : number,url : string }>()
)
export const loadProfileImageAction = createAction(
    "[Collection Post State] loadProfileImage",
    props<{ pageId : string, postId : number }>()
)
export const loadProfileImageSuccessAction = createAction(
    "[Collection Post State] loadProfileImageSuccessAction",
    props<{ pageId : string, postId : number, url : string }>()

)
export const setCurrentIndexOfPostImagesAction = createAction(
    "[Collection Post State] setCurrentPostImageAction",
    props<{ pageId : string, postId : number, index : number}>()
)