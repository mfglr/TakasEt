import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const initSearchPostListPageStateAction = createAction(
  "[Entity Search Post List Page Store] init search post list page",
  props<{postId : number}>()
)
export const nextPostsAction = createAction(
  "[Entity Search Post List Page Store] next posts",
  props<{postId : number}>()
)
export const nextPostsSuccessAction = createAction(
  "[Entity Search Post List Page Store] next posts success",
  props<{postId : number,payload : PostResponse[]}>()
)
