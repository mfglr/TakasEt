import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const loadPostsSuccessAction = createAction(
    "[Post Store] loadPostsSuccessAction",
    props<{ payload : PostResponse[]}>()
)
