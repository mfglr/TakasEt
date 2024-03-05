import { createReducer, on } from "@ngrx/store";
import { connectionFailedAction, connectionSuccessAction } from "./actions";

export interface ChatHubState{
  isConnected : boolean;
}


const intialState : ChatHubState = {
  isConnected : false
}

export const chatHubStateReducer = createReducer(
  intialState,
  on(connectionFailedAction,(state) => ({isConnected : false})),
  on(connectionSuccessAction,(state) => ({isConnected : true}))
)

