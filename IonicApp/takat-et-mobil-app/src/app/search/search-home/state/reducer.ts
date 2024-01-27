import { createReducer, on } from "@ngrx/store";
import { AppEntityState, takeValueOfPosts, takeValueOfUsers } from "src/app/state/app-entity-state/app-entity-state";
import { changeActiveIndex, nextPostsSuccessAction, nextUsersSuccessAction, searchUsersSuccessAction } from "./action";
import { PostResponse } from "src/app/models/responses/post-response";
import { UserResponse } from "src/app/models/responses/user-response";
import { appPostAdapter, appUserAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

export interface SearchHomePageState{
  posts : AppEntityState<PostResponse>,
  users : AppEntityState<UserResponse>,
  key : string | undefined,
  activeIndex : number
}

const initialState : SearchHomePageState = {
  posts : appPostAdapter.init(),
  users : appUserAdapter.init(),
  key : undefined,
  activeIndex : 0
}

export const searchHomePageReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({ ...state, posts : appPostAdapter.addMany(action.posts,state.posts) })
  ),
  on(
    nextUsersSuccessAction,
    (state,action) => ({...state,users : appUserAdapter.addMany(action.users,state.users)})
  ),
  // on(
  //   searchUsersSuccessAction,
  //   (state,action) => ({
  //     ...state,
  //     key : action.key,
  //     users : {
  //       entityIds : action.users.map(x => x.id),
  //       isLastEntities : action.users.length < takeValueOfUsers,
  //       page : {
  //         lastId : action.users.length > 0 ? action.users[action.users.length - 1].id : state.users.page.lastId,
  //         take : takeValueOfUsers
  //       }
  //     }
  //   })
  // ),
  on( changeActiveIndex,(state,action) => ({...state,activeIndex : action.activeIndex}) )
)
