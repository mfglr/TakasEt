import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, init } from "src/app/states/app-entity-state";
import { takeValueOfPosts } from "src/app/states/app-states";
import { nextPostsSuccessAction } from "./action";

export interface SearchHomePageState{
  posts : AppEntityState
}

const initialState : SearchHomePageState = {
  posts : init(takeValueOfPosts)
}

export const searchHomePageReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({ ...state, posts : addMany(action.posts.map(x => x.id),takeValueOfPosts,state.posts) })
  )
)
