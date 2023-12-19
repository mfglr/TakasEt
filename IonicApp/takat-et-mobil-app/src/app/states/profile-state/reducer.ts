import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, addOne, init, removeOne } from "src/app/states/app-entity-state";
import { takeValueOfPosts, takeValueOfUsers } from "src/app/states/app-states";
import { addOrRemoveFollowedAction, nextFollowedsSuccessAction, nextFollowersSuccessAction, nextNotSwappedPostsSuccessAction, nextPostsSuccessAction, nextSwappedPostsSuccessAction, removeFollowerAction } from "./actions";

export interface ProfileState{
  posts : AppEntityState;
  swappedPosts : AppEntityState;
  notSwappedPosts : AppEntityState;
  followers : AppEntityState;
  followeds : AppEntityState;
}

const initialState : ProfileState = {
  posts : init(takeValueOfPosts),
  swappedPosts : init(takeValueOfPosts),
  notSwappedPosts : init(takeValueOfPosts),
  followers : init(takeValueOfUsers),
  followeds : init(takeValueOfUsers),
}

export const profileReducer = createReducer(
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
    nextFollowedsSuccessAction,
    (state,action) => ({
      ...state,followeds : addMany(action.payload.map(x => x.id),takeValueOfUsers,state.followeds)
    })
  ),
  on(
    nextFollowersSuccessAction,
    (state,action) => ({
      ...state,followers : addMany(action.payload.map(x => x.id),takeValueOfUsers,state.followers)
    })
  ),
  on(
    addOrRemoveFollowedAction,
    (state,action) => {
      if(action.value)
        return {...state,followeds : addOne(action.followedId,state.followeds)};
      return {...state,followeds : removeOne(action.followedId,state.followeds)};
    }
  ),
  on(
    removeFollowerAction,
    (state,action) => ({...state,followers : removeOne(action.followerId,state.followers)})
  )
)
