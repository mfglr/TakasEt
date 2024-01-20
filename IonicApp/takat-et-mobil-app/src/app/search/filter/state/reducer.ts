import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, init, initMany, takeValueOfPosts } from "src/app/states/app-entity-state/app-entity-state";
import { filterPostsByCategoryIdsSuccessAction, filterPostsByKeySuccessAction,nextPostsSuccessAction } from "./actions";

export interface FilterPostsPageState{
  posts : AppEntityState,
  key : string | undefined,
  categoryIds : string | undefined
}

const initialState : FilterPostsPageState = {
  key : undefined,
  categoryIds : undefined,
  posts : init(takeValueOfPosts)
}

export const filterPostsPageReducer = createReducer(
  initialState,
  on(
    filterPostsByKeySuccessAction,
    (state,action) => ({
      ...state,
      key : action.key,
      posts : initMany(action.payload.map(x => x.id),takeValueOfPosts,state.posts)
    })
  ),

  on(
    filterPostsByCategoryIdsSuccessAction,
    (state,action) => ({
      ...state,
      categoryIds : action.categoryIds,
      posts : initMany(action.payload.map(x => x.id),takeValueOfPosts,state.posts)
    })
  ),

  on(
    nextPostsSuccessAction,
    (state,action) => ({
      ...state,
      posts : addMany(action.payload.map(x=> x.id),takeValueOfPosts,state.posts)
    })
  )
)
