import { createReducer, on } from "@ngrx/store";
import { PostResponse } from "src/app/models/responses/post-response";
import { AppEntityState } from "src/app/states/app-entity-state/app-entity-state";
import { nextPostsSuccessAction } from "./actions";
import { appPostAdapter, appStoryAdapter } from "src/app/states/app-entity-state/app-entity-adapter";
import { StoryResponse } from "src/app/models/responses/story-response";

export interface HomePageState{
  stories : AppEntityState<StoryResponse>
  posts : AppEntityState<PostResponse>
}

const initialState : HomePageState = {
  stories : appStoryAdapter.init(),
  posts : appPostAdapter.init()
}

export const HomePageReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({ ...state, posts : appPostAdapter.addMany(action.payload,state.posts) })
  )
)
