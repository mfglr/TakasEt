import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextPostsAction = createAction("[Search Home Page Store] next posts");
export const nextPostsSuccessAction = createAction(
  "[Search Home Page Store] next posts success",
  props<{posts : PostResponse[]}>()
)
