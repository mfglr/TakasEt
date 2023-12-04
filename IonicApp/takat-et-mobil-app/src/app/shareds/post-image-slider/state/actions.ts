import { createAction, props } from "@ngrx/store"
import { PostResponse } from "src/app/models/responses/post-response"

export const initPostImageSliderAction = createAction(
    "[Post Image Slider] initPostImageSliderAction",
    props<{post : PostResponse}>()
)
export const loadPostImageAction = createAction(
    "[Page Post State] loadPostImage",
    props<{postId : number, index : number}>()
)
export const loadPostImageSuccessAction = createAction(
    "[Page Post State] loadPostImageSuccessAction",
    props<{postId : number, index : number,url : string}>()
)
