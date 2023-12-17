import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, addOne, init, removeOne } from "src/app/states/app-entity-state";
import { takeValueOfPosts, takeValueOfUsers } from "src/app/states/app-states";
import { addFollowedAction, nextNotSwappedPostsSuccessAction, nextPostsSuccessAction, nextSwappedPostsSuccessAction, removeFollowedAction, removeFollowerAction } from "./actions";

export interface ProfileModuleState{
  posts : AppEntityState;
  swappedPosts : AppEntityState;
  notSwappedPosts : AppEntityState;
  followers : AppEntityState;
  followeds : AppEntityState;
}

const initialState : ProfileModuleState = {
  posts : init(takeValueOfPosts),
  swappedPosts : init(takeValueOfPosts),
  notSwappedPosts : init(takeValueOfPosts),
  followers : init(takeValueOfUsers),
  followeds : init(takeValueOfUsers),
}

export const profileModuleReducer = createReducer(
  initialState,
  on(
    nextPostsSuccessAction,
    (state,action) => ({...state,posts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.posts)})
  ),
  on(
    nextSwappedPostsSuccessAction,
    (state,action) => ({...state,swappedPosts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.swappedPosts)})
  ),
  on(
    nextNotSwappedPostsSuccessAction,
    (state,action) => ({
      ...state,
      notSwappedPosts : addMany(action.payload.map(x => x.id),takeValueOfPosts,state.notSwappedPosts)
    })
  ),
  on(
    addFollowedAction,
    (state,action) => ({...state,followeds : addOne(action.followedId,state.followeds)})
  ),
  on(
    removeFollowedAction,
    (state,action) => ({...state,followeds : removeOne(action.followedId,state.followeds)})
  ),
  on(
    removeFollowerAction,
    (state,action) => ({...state,followers : removeOne(action.followerId,state.followers)})
  )
)
