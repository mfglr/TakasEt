import { createReducer, on } from "@ngrx/store"
import { changeActiveIndexAction } from "./actions"

export interface ProfileFollowingPageState{
  activeIndex : number
}

const initialState : ProfileFollowingPageState = {
  activeIndex : 0
}

export const profileFollowingPageReducer = createReducer(
  initialState,
  on(changeActiveIndexAction,(state,action) => ({...state,activeIndex : action.activeTab}))
)
