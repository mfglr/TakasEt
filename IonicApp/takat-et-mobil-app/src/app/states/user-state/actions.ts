import { createAction, props } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";

export const loadUserAction = createAction("[User Store] load user",props<{userId : number}>())
export const loadUserSuccessAction = createAction("[User Store] load user success",props<{user : UserResponse}>())
export const loadUsersSuccessAction = createAction("[User Store] load users success",props<{users : UserResponse[]}>())
