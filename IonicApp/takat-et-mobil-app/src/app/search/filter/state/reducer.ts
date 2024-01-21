import { createReducer, on } from "@ngrx/store";
import { AppEntityState } from "src/app/states/app-entity-state/app-entity-state";
import { filterPostsByCategoryIdsSuccessAction, filterPostsByKeySuccessAction,nextPostsSuccessAction } from "./actions";
import { PostResponse } from "src/app/models/responses/post-response";
import { appPostAdapter } from "src/app/states/app-entity-state/app-entity-adapter";

export interface FilterPostsPageState{
  posts : AppEntityState<PostResponse>,
  key : string | undefined,
  categoryIds : string | undefined
}

const initialState : FilterPostsPageState = {
  key : undefined,
  categoryIds : undefined,
  posts : appPostAdapter.init()
}

export const filterPostsPageReducer = createReducer(
  initialState,
  on(
    filterPostsByKeySuccessAction,
    (state,action) => ({
      ...state,
      key : action.key,
      posts : appPostAdapter.initMany(action.payload,state.posts)
    })
  ),

  on(
    filterPostsByCategoryIdsSuccessAction,
    (state,action) => ({
      ...state,
      categoryIds : action.categoryIds,
      posts : appPostAdapter.initMany(action.payload,state.posts)
    })
  ),

  on(
    nextPostsSuccessAction,
    (state,action) => ({
      ...state,
      posts : appPostAdapter.addMany(action.payload,state.posts)
    })
  )
)
