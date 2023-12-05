import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPageAction = createAction( "[Home Page Store] nextPageAction" )
export const nextPageSuccessAction = createAction(
    "[Home Page Store] nextPageSuccessAction",
    props<{payload : PostResponse[]}>()
)