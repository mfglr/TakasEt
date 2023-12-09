import { createAction, props } from "@ngrx/store";

export const initStateAction = createAction(
    "[Post Like State]",
    props<{postId : number,likeStatus : boolean,countOfLikes : number}>()
)
export const switchAction = createAction("[Post Like State] switchAction",props<{postId : number}>())
export const commitAction = createAction("[Post Like State] commitAction",props<{postId : number}>())
export const commitSuccessAction = createAction(
    "[Post Like State] commitSuccessAction",
    props<{postId : number,value : boolean}>()
)