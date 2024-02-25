import { createAction, props } from "@ngrx/store";
import { LoginResponse } from "../models/login-response";

export const loginAction = createAction("[Login Store] login",props<{email : string,password : string}>());
export const loginByRefreshTokenAction = createAction(
  "[Login Store] login by refresh token",
  props<{userId : string,refreshToken : string}>()
)
export const loginByLocalStorageAction = createAction('[Login Store] login by local storage')
export const loginCompletedAction = createAction("[Login Store] login copleted",props<{payload : LoginResponse}>())
export const loginFailedAction = createAction('[Login Store] login from local storage failed');
