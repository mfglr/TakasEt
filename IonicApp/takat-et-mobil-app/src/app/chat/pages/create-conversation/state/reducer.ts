import { createReducer, on } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";
import { AppEntityState, Pagination } from "src/app/state/app-entity-state/app-entity-state";
import { nextPageUsersSuccessAction } from "./actions";
import { AppEntityAdapter } from "src/app/state/app-entity-state/app-entity-adapter";


export interface UserPageState extends Pagination<UserResponse>{}
export const userStateAdapter = new AppEntityAdapter<UserResponse,UserPageState>(20,undefined, false);

export interface CreateConversationPageState{
  users : AppEntityState<UserResponse,UserPageState>
}

const initialState : CreateConversationPageState = {
  users : userStateAdapter.init()
}

export const createConversationPageReducer = createReducer(
  initialState,
  on(
    nextPageUsersSuccessAction,
    (state,action) => ({
      ...state,
      users : userStateAdapter.nextPage(
        action.payload.map((x) : UserPageState => ({paginationProperty : x.userName,entity : x})),
        state.users
      )
    })
  )
)
