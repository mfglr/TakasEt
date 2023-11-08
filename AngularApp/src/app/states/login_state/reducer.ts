import { createReducer,on } from "@ngrx/store";
import { AppLoginState } from "./state";
import { loadProfileImageSuccess, loginFailedFromLocalStorage, loginSuccess } from "./actions";

const initialState : AppLoginState = { isLogin : false, profileImage : undefined, loginResponse : undefined };

export const appLoginReducer = createReducer(
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
  on(
    loadProfileImageSuccess,
    (state,action) => ({...state,profileImage : action.payload})
  )
)
