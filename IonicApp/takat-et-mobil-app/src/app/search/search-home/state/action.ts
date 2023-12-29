import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const searchPostsAction = createAction(
  "[Search Home Page Store] search posts",
  props<{key : string | undefined}>()
)
export const searchPostsSuccessAction = createAction(
  "[Search Home Page Store] search posts success",
  props<{key : string | undefined,posts : PostResponse[]}>()
)
export const nextPostsAction = createAction("[Search Home Page Store] next posts");
export const nextPostsSuccessAction = createAction(
  "[Search Home Page Store] next posts success",
  props<{posts : PostResponse[]}>()
)
