import { createReducer, on } from "@ngrx/store"
import { changeActiveTabAction } from "./actions"

export interface ProfileFollowingPageState{
  activeTab : number
}

const initialState : ProfileFollowingPageState = {
  activeTab : 0
}

export const profileFollowingPageReducer = createReducer(
  initialState,
  on(changeActiveTabAction,(state,action) => ({...state,activeTab : action.activeTab}))
)
