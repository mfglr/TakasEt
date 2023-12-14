import { createAction, props } from "@ngrx/store"
import { PostResponse } from "src/app/models/responses/post-response"

export const initUserModuleAction = createAction(
  "[User Modal Store] init user modal",
  props<{userId : number}>()
)
export const nextPostsAction = createAction(
  "[User Modal Store] next posts",
  props<{userId : number}>()
)
export const nextPostsSuccessAction = createAction(
  "[User Modal Store] next posts success",
  props<{userId : number,payload : PostResponse[]}>()
)
export const nextSwappedPostsAction = createAction(
  "[User Modal Store] next swapped posts",
  props<{userId : number}>()
)
export const nextSwappedPostsSuccessAction = createAction(
  "[User Modal Store] next swapped posts success",
  props<{userId : number,payload : PostResponse[]}>()
)
export const nextNotSwappedPostsAction = createAction(
  "[User Modal Store] next not swapped posts",
  props<{userId : number}>()
)
export const nextNotSwappedPostsSuccessAction = createAction(
  "[User Modal Store] next not swapped posts success",
  props<{userId : number,payload : PostResponse[]}>()
)
