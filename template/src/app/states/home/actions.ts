import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";

export const getPosts = createAction("get posts")
export const getPostsSuccess = createAction(
  "get posts success",
  props<{posts : PostResponse[]}>()
)
