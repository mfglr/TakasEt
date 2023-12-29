import { createReducer, on } from "@ngrx/store";
import { nextPostsSuccessAction } from "./actions";
import { AppEntityState, addMany, init, takeValueOfPosts } from "src/app/states/app-entity-state";

export interface HomePageState{
  posts : AppEntityState
}

const initialState : HomePageState = {
  posts : init(takeValueOfPosts)
}
export const homePageReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({ posts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.posts) })
  )
)
