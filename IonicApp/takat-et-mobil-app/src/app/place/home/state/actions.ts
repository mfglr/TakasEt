import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageAction = createAction( "[Page Post State] nextPageAction" )
export const nextPageSuccessAction = createAction(
    "[Page Post State] nextPageSuccessAction",
    props<{ payload : PostResponse[] }>()
)