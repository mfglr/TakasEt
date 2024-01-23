import { createReducer, on } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { UserResponse } from "src/app/models/responses/user-response";
import { AppEntityState } from "src/app/states/app-entity-state/app-entity-state";
import { loadUserSuccessAction, nextPostsSuccessAction } from "./actions";
import { appPostAdapter } from "src/app/states/app-entity-state/app-entity-adapter";

export interface HomePageState{
  user : UserResponse | undefined
  posts : AppEntityState<PostResponse>
}

const initialState : HomePageState = {
  user : undefined,
  posts : appPostAdapter.init()
}

export const HomePageReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({ ...state, posts : appPostAdapter.addMany(action.payload,state.posts) })
  ),
  on( loadUserSuccessAction, (state,action) => ({...state, user : action.payload }) )
)
