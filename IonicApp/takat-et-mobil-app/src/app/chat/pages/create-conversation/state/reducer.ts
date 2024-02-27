import { createReducer, on } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";
import { appUserAdapter } from "src/app/state/app-entity-state/app-entity-adapter";
import { AppEntityState } from "src/app/state/app-entity-state/app-entity-state";
import { nextPageUsersSuccessAction } from "./actions";

export interface CreateConversationPageState{
  users : AppEntityState<UserResponse>
}

const initialState : CreateConversationPageState = {
  users : appUserAdapter.init()
}

export const CreateConversationPageReducer = createReducer(
  initialState,
  on(nextPageUsersSuccessAction,(state,action) => ({...state, users : appUserAdapter.addMany(action.payload,state.users)}))
)
