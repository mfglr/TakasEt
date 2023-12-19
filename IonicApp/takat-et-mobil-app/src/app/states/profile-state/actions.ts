import { createAction, props } from "@ngrx/store"
import { PostResponse } from "src/app/models/responses/post-response"
import { UserResponse } from "src/app/models/responses/user-response"

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

export const nextNotSwappedPostsAction = createAction("[Profile Modal Store] next not swapped posts")
export const nextNotSwappedPostsSuccessAction = createAction(
  "[Profile Modal Store] next not swapped posts success",
  props<{payload : PostResponse[]}>()
)

export const nextFollowedsAction = createAction("[Profile Modal Store] next followeds");
export const nextFollowedsSuccessAction = createAction(
  "[Profile Modal Store] next followeds success",
  props<{payload : UserResponse[]}>()
)

export const nextFollowersAction = createAction("[Profile Modal Store] next followers")
export const nextFollowersSuccessAction = createAction(
  "[Profile Modal Store] next followers success",
  props<{payload : UserResponse[]}>()
)

export const addOrRemoveFollowedAction = createAction(
  "[Profile Modal Store] add or remove followed",
  props<{followedId : number,value : boolean}>()
)
export const removeFollowerAction = createAction(
  "[Profile Modal Store] remove follower",
  props<{followerId : number}>()
)
