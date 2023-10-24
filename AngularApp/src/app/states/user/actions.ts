import { createAction, props } from "@ngrx/store";
import { LoginResponse } from "src/app/models/responses/login-response";

export const login = createAction( "login",props<{email : string,password : string}>() );
export const loginByRefreshToken = createAction("loginByRefreshToken",props<{refreshToken : string}>())
export const loginFromLocalStorage = createAction('loginFromLocalStorage')
export const loginFailedFromLocalStorage = createAction('loginFailedFromLocalStorage');
export const loginSuccess = createAction( "login success", props<{payload : LoginResponse}>() )
