import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, init } from "src/app/states/app-entity-state";
import { takeValueOfPosts } from "src/app/states/app-states";
import { nextAbstractPostsSuccessAction } from "./action";

export interface SearchHomePageState{
  abstractPosts : AppEntityState
}

const initialState : SearchHomePageState = {
  abstractPosts : init(takeValueOfPosts)
}

export const searchHomePageReducer = createReducer(
  initialState,
  on(
    nextAbstractPostsSuccessAction,
    (state,action) => ({
      ...state,
      abstractPosts : addMany(action.posts.map(x => x.id),takeValueOfPosts,state.abstractPosts)
    })
  )
)
