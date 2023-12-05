import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageAction = createAction( "[Search Page Store] nextPageAction" )
export const nextPageSuccessAction = createAction(
    "[Search Page Store] nextPageSuccessAction",
    props<{payload : PostResponse[]}>()
)