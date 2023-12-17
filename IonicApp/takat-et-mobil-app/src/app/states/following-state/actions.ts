import { createAction, props } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";

export const initFollowingStateAction = createAction(
  "[Following Store] init following state",
  props<{user : UserResponse}>()
)
export const initFollowingStatesAction = createAction(
  "[Following Store] init following states",
  props<{users : UserResponse[]}>()
)
export const changeFollowedValueAction = createAction(
  "[Following Store] switch followed value",
  props<{userId : number,value : boolean}>()
)
export const commitFollowedValueAction = createAction(
  "[Following Store] commit followed value",
  props<{userId : number}>()
)
export const commitFollowedValueSuccessAction = createAction(
  "[Following Store] commit followed value success",
  props<{userId : number,value : boolean}>()
)
export const removeFollowerAction = createAction(
  "[Following Store] remove follower",
  props<{userId : number}>()
)
export const removeFollowerSuccessAction = createAction(
  "[Following Store] remove follower success",
  props<{userId : number}>()
)
