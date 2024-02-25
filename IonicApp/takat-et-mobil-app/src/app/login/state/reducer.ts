import { createReducer, on } from "@ngrx/store";
import { LoginResponse } from "../models/login-response";
import { loginCompletedAction, loginFailedAction } from "./actions";

export interface LoginState{
  loginResponse : LoginResponse | undefined;
  isLogin : boolean;
}

const initialState : LoginState = {
  loginResponse : undefined,
  isLogin : false
}

export const loginReducer = createReducer(
  initialState,
  on(loginCompletedAction,(state,action) => {
    localStorage.setItem('login_response',JSON.stringify(action.payload));
    return {loginResponse : action.payload,isLogin : true}
  }),
  on(loginFailedAction,(state) => ({...state,isLogin : false}))
)
