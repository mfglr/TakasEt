import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const initPageState = createAction(
  "[Explore Page Store] initPageState",
  props<{post : PostResponse}>()
)
export const nextPageAction = createAction(
  "[Explore Page Store] nextPageAction",
  props<{postId : number}>()
);
export const nextPageSuccessAction = createAction(
  "[Explore Page Store] nextPageSuccessAction",
  props<{postId : number,payload : PostResponse[]}>()
)
