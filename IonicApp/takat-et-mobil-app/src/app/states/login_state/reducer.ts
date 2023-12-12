import { createReducer,on } from "@ngrx/store";
import { loginFailedFromLocalStorage, loginSuccess} from "./actions";
import { LoginResponse } from "src/app/models/responses/login-response";

export interface LoginState{
  loginResponse : LoginResponse | undefined;
  isLogin : boolean;
}

const initialState : LoginState = {
  isLogin : false,
  loginResponse : undefined,
};

export const loginReducer = createReducer(
  initialState,
  on(
    loginSuccess,
    (state,action) => {
      localStorage.setItem('login_response',JSON.stringify(action.payload));
      return {...state,loginResponse : action.payload,isLogin : true }
    }
  ),
  on(
    loginFailedFromLocalStorage,
    (state) => {
      console.log('loginFailedFromLocalStorage');
      return state;
    }
  ),
)
