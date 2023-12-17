import { createAction, props } from "@ngrx/store"
import { PostResponse } from "src/app/models/responses/post-response"
import { UserResponse } from "src/app/models/responses/user-response"

export const initUserModuleStateAction = createAction(
  "[User Modal Store] init user modal state",
  props<{userId: number}>()
)
export const initUserModuleStatesAction = createAction(
  "[User Modal Store] init user modal states",
  props<{users : UserResponse[]}>()
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
export const nextFollowersAction = createAction(
  "[User Module Store] next followers",
  props<{userId : number}>()
)
export const nextFollowersSuccessAction = createAction(
  "[User Module Store] next followers success",
  props<{userId : number,payload : UserResponse[]}>()
)
export const nextFollowedsAction = createAction(
  "[User Module Store] next followeds",
  props<{userId : number}>()
)
export const nextFollowedsSuccessAction = createAction(
  "[User Module Store] next followeds success",
  props<{userId : number,payload : UserResponse[]}>()
)
export const unfollowAction = createAction(
  "[User Module Store] unfollow action",
  props<{userId : number}>()
)
