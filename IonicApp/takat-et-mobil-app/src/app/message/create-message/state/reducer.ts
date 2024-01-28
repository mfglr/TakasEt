import { createReducer, on } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";
import { appUserAdapter } from "src/app/state/app-entity-state/app-entity-adapter";
import { AppEntityState } from "src/app/state/app-entity-state/app-entity-state";
import { nextPageUsersSuccessAction } from "./actions";

export interface CreateMessagePageState{
  users : AppEntityState<UserResponse>
}

const initialState : CreateMessagePageState = {
  users : appUserAdapter.init()
}

export const createMessagePageReducer = createReducer(
  initialState,
  on(
    nextPageUsersSuccessAction,
    (state,action) => ({ users : appUserAdapter.addMany(action.payload,state.users) })
  )
)
