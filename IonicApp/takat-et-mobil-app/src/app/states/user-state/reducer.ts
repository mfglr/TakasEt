import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";
import { loadUserSuccessAction, loadUsersSuccessAction } from "./actions";

export interface UserState extends EntityState<UserResponse>{}

const adapter = createEntityAdapter<UserResponse>({
    selectId : state => state.id
})

export const userReducer = createReducer(
    adapter.getInitialState(),
    on(loadUserSuccessAction,(state,action) => adapter.addOne(action.user,state)),
    on(loadUsersSuccessAction,(state,action) => adapter.addMany(action.users,state))
)
