import { createAction, props } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";

export const loadUserAction = createAction("[User Store] load user",props<{userId : number}>())
export const loadUserSuccessAction = createAction("[User Store] load user success",props<{user : UserResponse}>())
export const loadUsersSuccessAction = createAction("[User Store] load users success",props<{users : UserResponse[]}>())
export const followAction = createAction("[User Store] follow",props<{userId : number}>())


export const changeFollowingStatusAction = createAction(
  "[User Store] change following status",
  props<{userId : number,logginUserId : number,value : boolean}>()
)
export const commitFollowingStatusAction = createAction(
  "[User Store] unfollow",
  props<{userId : number,value : boolean}>()
)
export const commitFollowingStatusSuccessAction = createAction("[User Store] commit following status success")
