import { createReducer, on } from "@ngrx/store";
import { changeActiveTabAction } from "./actions";

export interface ProfilePageState{
  activeTab : number;
}

const initialState : ProfilePageState = {
  activeTab : 0
}

export const profilePageReducer = createReducer(
  initialState,
  on( changeActiveTabAction, (state,action) => ({ ...state, activeTab : action.activeTab }) ),
)
