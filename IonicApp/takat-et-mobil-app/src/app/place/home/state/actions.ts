import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPostsAction = createAction( "[Home Page Store] nextPageAction" )
export const nextPostsSuccessAction = createAction(
    "[Home Page Store] nextPageSuccessAction",
    props<{payload : PostResponse[]}>()
)
