import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const initCategoryPageState = createAction(
  "[Category Page Collection Store] init category page state",
  props<{categoryId : number}>()
)
export const nextPostsAction = createAction(
  "[Category Page Collection Store] next posts",
  props<{categoryId : number}>()
)
export const nextPostsSuccessAction = createAction(
  "[Category Page Collection Store] next posts success",
  props<{categoryId : number,payload : PostResponse[]}>()
)
