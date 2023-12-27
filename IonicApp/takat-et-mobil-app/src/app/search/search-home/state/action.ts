import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const nextAbstractPostsAction = createAction("[Search Home Page Store] next posts");
export const nextAbstractPostsSuccessAction = createAction(
  "[Search Home Page Store] next posts success",
  props<{posts : PostResponse[]}>()
)
