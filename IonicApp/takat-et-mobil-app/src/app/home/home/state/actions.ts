import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPostsAction = createAction("[Home Page Store] next posts")
export const nextPostsSuccessAction = createAction(
  "[Home Page Store] next posts success",
  props<{payload : PostResponse[]}>()
)
