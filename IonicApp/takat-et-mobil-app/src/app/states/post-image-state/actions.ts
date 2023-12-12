import { createAction, props } from "@ngrx/store";
import { PostImageResponse } from "src/app/models/responses/post-image-response";


export const loadPostImageSuccessAction = createAction(
  "[Post Image] loadPostImageSuccessAction",
  props<{postImage : PostImageResponse}>()
)

export const loadPostImagesSuccessAction = createAction(
    "[Post Image] loadPostImagesSuccessAction",
    props<{postImages : PostImageResponse[]}>()
)

export const loadPostImageUrlAction = createAction(
    "[Post Image] loadPostImageUrlAction",
    props<{id : number}>()
)
export const loadPostImageUrlSuccessAction = createAction(
    "[Post Image] loadPostImageUrlSuccessAction",
    props<{id : number,url : string}>()
)
