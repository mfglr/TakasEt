import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const addPostsAction = createAction(
    "[Post Store] addPostsAction",
    props<{ payload : PostResponse[]}>()
)