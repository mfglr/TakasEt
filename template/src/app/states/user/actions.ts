import { createAction, props } from "@ngrx/store";
import { UserState } from "./state";
import { LoginResponse } from "src/app/models/responses/login-response";

export const login = createAction(
  "login",
  props<{email : string,password : string}>()
);
export const loginSuccess = createAction(
  "login success",
  props<{payload : LoginResponse}>()
)

export const setHttpHeaders = createAction(
  "set httpHeaders",
  props<{accessToken : string}>()
)
