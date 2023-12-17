import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";
import { loadUserSuccessAction, loadUsersSuccessAction } from "./actions";


export interface UserState{user : UserResponse;loadStatus : boolean;}
export interface UserEntityState extends EntityState<UserState>{}

const adapter = createEntityAdapter<UserState>({selectId : state => state.user.id})

export const userEntityReducer = createReducer(
  adapter.getInitialState(),
  on(loadUserSuccessAction,(state,action) => adapter.addOne({ user : action.user,loadStatus : true },state)),
  on(
    loadUsersSuccessAction,
    (state,action) => adapter.addMany(action.users.map(
      user => ({user : user,loadStatus : true})
    ),state)
  ),
)
