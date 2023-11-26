import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageAction = createAction(
    "[Page Post State] nextPageAction",
    props<{ pageId : string }>()
)
export const nextPageSuccessAction = createAction(
    "[Page Post State] nextPageSuccessAction",
    props<{ pageId : string, payload : PostResponse[] }>()
)
export const loadPostImageAction = createAction(
    "[Page Post State] loadPostImage",
    props<{ pageId : string, postId : number, index : number }>()
)
export const loadPostImageSuccessAction = createAction(
    "[Page Post State] loadPostImageSuccessAction",
    props<{ pageId : string, postId : number, index : number,url : string }>()
)
export const loadNextPostImageAction = createAction(
    "[Page Post State] loadNextPostImageAction",
    props<{pageId : string,postId : number}>()
)
export const loadProfileImageAction = createAction(
    "[Page Post State] loadProfileImage",
    props<{ pageId : string, postId : number }>()
)
export const loadProfileImageSuccessAction = createAction(
    "[Page Post State] loadProfileImageSuccessAction",
    props<{ pageId : string, postId : number, url : string }>()

)
export const setCurrentIndexOfPostImagesAction = createAction(
    "[Page Post State] setCurrentPostImageAction",
    props<{ pageId : string, postId : number, index : number}>()
)
export const initHomePageAction = createAction("[Page Post State] initHomePageAction");
export const initSearchPageAction = createAction("[Page Post State] initSearchPageAction");

export const switchLikeStatusAction = createAction(
    "[Page Post State] switchLikeStatusAction",
    props<{pageId : string,postId : number}>()
)
export const switchLikeStatusSuccessAction = createAction(
    "[Page Post State] switchLikeStatusSuccessAction",
    props<{pageId : string,postId : number}>()
)


