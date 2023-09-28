import { createReducer,on } from "@ngrx/store";
import { UserState } from "./state";
import { loginSuccess } from "./actions";

const initialState : UserState = {
  loginResponse : undefined,
  isLogin : false
};

export const userReducer = createReducer(
  initialState,
  on(loginSuccess,(state,action) : UserState =>{
    return {...state, loginResponse : action.payload, isLogin : true }
  })
)
