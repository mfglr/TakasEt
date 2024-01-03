import { createAction, props } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { UserResponse } from "src/app/models/responses/user-response";

export const searchPostsAction = createAction(
  "[Search Home Page Store] search posts",
  props<{key : string | undefined}>()
)
export const searchPostsSuccessAction = createAction(
  "[Search Home Page Store] search posts success",
  props<{key : string | undefined,posts : PostResponse[]}>()
)

export const searchUsersAction = createAction(
  "[Search Home Page Store] search users",
  props<{key : string | undefined}>()
)
export const searchUsersSuccessAction = createAction(
  "[Search Home Page Store] search users success",
  props<{key : string | undefined,users : UserResponse[]}>()
)

export const nextPostsAction = createAction("[Search Home Page Store] next posts");
export const nextPostsSuccessAction = createAction(
  "[Search Home Page Store] next posts success",
  props<{posts : PostResponse[]}>()
)

export const nextUsersAction = createAction("[Search Home Page Store] next users")
export const nextUsersSuccessAction = createAction(
  "[Search Home Page Store] next users success",
  props<{users : UserResponse[]}>()
)

export const changeActiveIndex = createAction(
  "[Search Home Page Store] change active index",
  props<{activeIndex : number}>()
)
