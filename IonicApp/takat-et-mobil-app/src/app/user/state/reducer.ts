import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, init, takeValueOfPosts, takeValueOfUsers } from "src/app/states/app-entity-state";
import { initUserModuleStateAction, initUserModuleStatesAction, nextFollowedsSuccessAction, nextFollowersSuccessAction, nextNotSwappedPostsSuccessAction, nextPostsSuccessAction, nextSwappedPostsSuccessAction } from "./actions";

interface UserModuleState{
  userId : number;
  posts : AppEntityState;
  swappedPosts : AppEntityState;
  notSwappedPosts : AppEntityState;
  followers : AppEntityState;
  followeds : AppEntityState;
}

export interface UserModuleCollectionState extends EntityState<UserModuleState>{}
const adapter = createEntityAdapter<UserModuleState>({selectId : x => x.userId})

export const userModuleCollectionReducer = createReducer(
  adapter.getInitialState(),
  on(
    initUserModuleStateAction,
    (state,action) => adapter.addOne({
      userId : action.userId,
      posts : init(takeValueOfPosts),
      swappedPosts : init(takeValueOfPosts),
      notSwappedPosts : init(takeValueOfPosts),
      followers : init(takeValueOfUsers),
      followeds : init(takeValueOfUsers)
    },state)
  ),
  on(
    initUserModuleStatesAction,
    (state,action) => adapter.addMany(action.users.map(user => ({
      userId : user.id,
      posts : init(takeValueOfPosts),
      swappedPosts : init(takeValueOfPosts),
      notSwappedPosts : init(takeValueOfPosts),
      followers : init(takeValueOfUsers),
      followeds : init(takeValueOfUsers)
    })),state)
  ),
  on(
    nextPostsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        posts : addMany(
          action.payload.map(x => x.id),
          takeValueOfPosts,
          state.entities[action.userId]!.posts
        )
      }
    },state)
  ),
  on(
    nextSwappedPostsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        swappedPosts : addMany(
          action.payload.map(x => x.id),
          takeValueOfPosts,
          state.entities[action.userId]!.swappedPosts
        )
      }
    },state)
  ),
  on(
    nextNotSwappedPostsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        notSwappedPosts : addMany(
          action.payload.map(x => x.id),
          takeValueOfPosts,
          state.entities[action.userId]!.notSwappedPosts
        )
      }
    },state)
  ),
  on(
    nextFollowersSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        followers : addMany(
          action.payload.map(x => x.id),
          takeValueOfUsers,
          state.entities[action.userId]!.followers
        )
      }
    },state)
  ),
  on(
    nextFollowedsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        followeds : addMany(
          action.payload.map(x => x.id),
          takeValueOfUsers,
          state.entities[action.userId]!.followeds
        )
      }
    },state)
  ),
)
