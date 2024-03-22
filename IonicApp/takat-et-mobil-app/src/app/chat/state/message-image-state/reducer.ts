import { createReducer, on } from "@ngrx/store"
import { addImageAction, removeImageAction } from "./actions"

export interface MessageImageCreationState{
  urls : (string | undefined)[]
}

const initialState : MessageImageCreationState = {
  urls : []
}


export const MessageImageReducer = createReducer(
  initialState,
  on(addImageAction,(state,action) => ({urls : [...state.urls,action.url]})),
  on(removeImageAction,(state,action) => ({urls : [...state.urls].splice(action.index,1)}))
)
