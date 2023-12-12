import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPostsAction = createAction( "[Search Page Store] nextPageAction" )
export const nextPostsSuccessAction = createAction(
    "[Search Page Store] nextPageSuccessAction",
    props<{payload : PostResponse[]}>()
)
