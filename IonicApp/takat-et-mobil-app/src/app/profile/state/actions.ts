import { createAction, props } from "@ngrx/store"
import { PostResponse } from "src/app/models/responses/post-response"
export const nextPostsAction = createAction("[Profile Modal Store] next posts")
export const nextPostsSuccessAction = createAction(
  "[Profile Modal Store] next posts success",
  props<{payload : PostResponse[]}>()
)

export const nextSwappedPostsAction = createAction("[Profile Modal Store] next swapped posts")
export const nextSwappedPostsSuccessAction = createAction(
  "[Profile Modal Store] next swapped posts success",
  props<{payload : PostResponse[]}>()
)

export const nextNotSwappedPostsAction = createAction("[Profile Modal Store] next not swapped posts",)
export const nextNotSwappedPostsSuccessAction = createAction(
  "[Profile Modal Store] next not swapped posts success",
  props<{payload : PostResponse[]}>()
)
