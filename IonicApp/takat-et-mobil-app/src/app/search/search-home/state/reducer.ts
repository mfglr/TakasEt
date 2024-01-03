import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, init, takeValueOfPosts, takeValueOfUsers } from "src/app/states/app-entity-state";
import { changeActiveIndex, nextPostsSuccessAction, nextUsersSuccessAction, searchPostsSuccessAction, searchUsersSuccessAction } from "./action";

export interface SearchHomePageState{
  posts : AppEntityState,
  users : AppEntityState,
  key : string | undefined,
  activeIndex : number
}

const initialState : SearchHomePageState = {
  posts : init(takeValueOfPosts),
  users : init(takeValueOfUsers),
  key : undefined,
  activeIndex : 0
}

export const searchHomePageReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({ ...state, posts : addMany(action.posts.map(x => x.id),takeValueOfPosts,state.posts) })
  ),
  on(
    nextUsersSuccessAction,
    (state,action) => ({...state,users : addMany(action.users.map(x => x.id),takeValueOfUsers,state.users)})
  ),
  on(
    searchPostsSuccessAction,
    (state,action) => ({
      ...state,
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
  ),
  on(
    searchUsersSuccessAction,
    (state,action) => ({
      ...state,
      key : action.key,
      users : {
        entityIds : action.users.map(x => x.id),
        isLastEntities : action.users.length < takeValueOfUsers,
        page : {
          lastId : action.users.length > 0 ? action.users[action.users.length - 1].id : undefined,
          take : takeValueOfUsers
        }
      }
    })
  ),
  on( changeActiveIndex,(state,action) => ({...state,activeIndex : action.activeIndex}) )
)
