import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const initPageState = createAction(
  "[Explore Page Store] init page state",
  props<{post : PostResponse}>()
)
export const nextPostsAction = createAction(
  "[Explore Page Store] next posts",
  props<{postId : number}>()
);
export const nextPostsSuccessAction = createAction(
  "[Explore Page Store] next posts success",
  props<{postId : number,payload : PostResponse[]}>()
)
