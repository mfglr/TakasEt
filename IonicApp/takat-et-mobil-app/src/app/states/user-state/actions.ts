import { createAction, props } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";

export const addUser = createAction("[User Store] addUser",props<{user : UserResponse}>())
export const addUsers = createAction("[User Store] addUsers",props<{users : UserResponse[]}>())