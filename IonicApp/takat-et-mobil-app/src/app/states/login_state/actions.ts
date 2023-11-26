import { createAction, props } from "@ngrx/store";
import { LoginResponse } from "src/app/models/responses/login-response";

export const login = createAction( "[Login] login",props<{email : string,password : string}>() );
export const loadProfileImage = createAction("[Login] loadProfileImage");
export const loadProfileImageSuccess = createAction("[Login] loadProfileImageSuccess",props<{payload : string}>())
export const loginByRefreshToken = createAction("[Login] loginByRefreshToken",props<{refreshToken : string}>())
export const loginFromLocalStorage = createAction('[Login] loginFromLocalStorage')
export const loginFailedFromLocalStorage = createAction('[Login] loginFailedFromLocalStorage');
export const loginSuccess = createAction( "[Login] login success", props<{payload : LoginResponse}>() )