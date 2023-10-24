import { createReducer,on } from "@ngrx/store";
import { UserState } from "./state";
import { loginFailedFromLocalStorage, loginSuccess } from "./actions";

const initialState : UserState = {
  loginResponse : undefined,
  isLogin : false
};

export const userReducer = createReducer(
  initialState,
  on(loginSuccess,(state,action) : UserState =>{
    localStorage.setItem('loginResponse',JSON.stringify(action.payload));
    return {...state, loginResponse : action.payload, isLogin : true }
  }),
  on(loginFailedFromLocalStorage,(state) : UserState => {
    console.log('loginFailedFromLocalStorage');
    return {...state};
  })
)
