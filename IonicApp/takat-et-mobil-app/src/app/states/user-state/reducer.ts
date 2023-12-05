import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { UserResponse } from "src/app/models/responses/user-response";
import { addUser, addUsers } from "./actions";

export interface UserState extends EntityState<UserResponse>{}

const adapter = createEntityAdapter<UserResponse>({
    selectId : state => state.id
})

export const entityUserReducer = createReducer(
    adapter.getInitialState(),
    on(addUser,(state,action) => adapter.addOne(action.user,state)),
    on(addUsers,(state,action) => adapter.addMany(action.users,state))
)