import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, init } from "src/app/states/app-entity-state";
import { takeValueOfPosts } from "src/app/states/app-states";
import { nextNotSwappedPostsSuccessAction, nextPostsSuccessAction, nextSwappedPostsSuccessAction } from "./actions";

export interface ProfileModuleState{
  posts : AppEntityState;
  swappedPosts : AppEntityState;
  notSwappedPosts : AppEntityState;
}

const initialState : ProfileModuleState = {
  posts : init(takeValueOfPosts),
  swappedPosts : init(takeValueOfPosts),
  notSwappedPosts : init(takeValueOfPosts)
}

export const profileModuleReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({...state,posts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.posts)})
  ),
  on(
    nextSwappedPostsSuccessAction,
    (state,action) => ({...state,swappedPosts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.swappedPosts)})
  ),
  on(
    nextNotSwappedPostsSuccessAction,
    (state,action) => ({...state,notSwappedPosts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.notSwappedPosts)})
  )
)
