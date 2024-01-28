import { createAction, props } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";

export const nextPageUsersAction = createAction("[Create Message Page Store] next page users")
export const nextPageUsersSuccessAction = createAction(
  "[Create Message Page Store] next page users success",
  props<{payload : UserResponse[]}>()
)
