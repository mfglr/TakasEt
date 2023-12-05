import { createAction, props } from "@ngrx/store";
import { PostImageResponse } from "src/app/models/responses/post-image-response";

export const addPostImagesAction = createAction(
    "[Post Image] addPostImages",
    props<{postImages : PostImageResponse[]}>()
)
export const addPostImage = createAction(
    "[Post Image] addPostImage",
    props<{postImage : PostImageResponse}>()
)
export const loadPostImageAction = createAction(
    "[Post Image] loadPostImageAction",
    props<{id : number}>()
)
export const loadPostImageSuccessAction = createAction(
    "[Post Image] loadPostImageSuccessAction",
    props<{id : number,url : string}>()
)