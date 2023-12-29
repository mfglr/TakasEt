import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, init, takeValueOfPosts } from "src/app/states/app-entity-state";
import { nextPostsSuccessAction, searchPostsSuccessAction } from "./action";

export interface SearchHomePageState{
  posts : AppEntityState,
  key : string | undefined
}

const initialState : SearchHomePageState = {
  posts : init(takeValueOfPosts),
  key : undefined
}

export const searchHomePageReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({ ...state, posts : addMany(action.posts.map(x => x.id),takeValueOfPosts,state.posts) })
  ),
  on(
    searchPostsSuccessAction,
    (state,action) => ({
      key : action.key,
      posts : {
        entityIds : action.posts.map(x => x.id),
        isLastEntities : action.posts.length < takeValueOfPosts,
        page : {
          lastId : action.posts.length > 0 ? action.posts[action.posts.length - 1].id : undefined,
          take : takeValueOfPosts
        }
      }
    })
  )
)
