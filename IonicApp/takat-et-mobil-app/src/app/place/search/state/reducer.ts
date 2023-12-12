import { createReducer, on } from "@ngrx/store";
import { takeValueOfPosts } from "src/app/states/app-states";
import { nextPostsSuccessAction } from "./actions";
import { AppEntityState, addMany, init } from "src/app/states/app-entity-state";

export interface SearchPageState{
  posts : AppEntityState
}

const initialState : SearchPageState = {
  posts : init(takeValueOfPosts)
}
export const searchPageReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({
      posts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.posts)
    })
  )
)
