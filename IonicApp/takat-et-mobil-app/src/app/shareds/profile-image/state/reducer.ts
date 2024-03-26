import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { loadUserImageSuccessAction } from "./actions";
import { ImageLoadingState } from "src/app/models/enums/image-loading-state";


export interface UserImageState{
  id : string;
  blobName : string;
  extention : string,
  url : string;
  status : ImageLoadingState;
}

export interface UserImageEntityState extends EntityState<UserImageState>{}

export const adapter = createEntityAdapter<UserImageState>({
  selectId : state => state.id
})

export const userImageReducer = createReducer(
  adapter.getInitialState(),
  on(
    loadUserImageSuccessAction,
    (state,action) => adapter.addOne({
      ...state.entities[action.id]!,
      id : action.id,
      url : action.url
    },state)
  )
)

