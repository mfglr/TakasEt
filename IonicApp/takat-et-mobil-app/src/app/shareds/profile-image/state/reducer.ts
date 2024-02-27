import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { loadUserImageSuccessAction } from "./actions";

interface UserImageState{
  id : string;
  url : string;
}

export interface UserImageEntityState extends EntityState<UserImageState>{}

export const adapter = createEntityAdapter<UserImageState>({
  selectId : state => state.id
})

export const userImageReducer = createReducer(
  adapter.getInitialState(),
  on( loadUserImageSuccessAction,(state,action) => adapter.addOne({id : action.id,url : action.url},state) )
)

