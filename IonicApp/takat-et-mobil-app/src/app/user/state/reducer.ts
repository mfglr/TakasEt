import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { AppEntityState } from "src/app/states/app-entity-state/app-entity-state";
import { initUserModuleStateAction, initUserModuleStatesAction, nextFollowedsSuccessAction, nextFollowersSuccessAction, nextNotSwappedPostsSuccessAction, nextPostsSuccessAction, nextSwappedPostsSuccessAction } from "./actions";
import { PostResponse } from "src/app/models/responses/post-response";
import { UserResponse } from "src/app/models/responses/user-response";
import { appPostAdapter, appUserAdapter } from "src/app/states/app-entity-state/app-entity-adapter";

interface UserModuleState{
  userId : number;
  posts : AppEntityState<PostResponse>;
  swappedPosts : AppEntityState<PostResponse>;
  notSwappedPosts : AppEntityState<PostResponse>;
  followers : AppEntityState<UserResponse>;
  followeds : AppEntityState<UserResponse>;
}

export interface UserModuleCollectionState extends EntityState<UserModuleState>{}
const adapter = createEntityAdapter<UserModuleState>({selectId : x => x.userId})

export const userModuleCollectionReducer = createReducer(
  adapter.getInitialState(),
  on(
    initUserModuleStateAction,
    (state,action) => adapter.addOne({
      userId : action.userId,
      posts : appPostAdapter.init(),
      swappedPosts : appPostAdapter.init(),
      notSwappedPosts :appPostAdapter.init(),
      followers : appUserAdapter.init(),
      followeds : appUserAdapter.init()
    },state)
  ),
  on(
    initUserModuleStatesAction,
    (state,action) => adapter.addMany(action.users.map(user => ({
      userId : user.id,
      posts : appPostAdapter.init(),
      swappedPosts : appPostAdapter.init(),
      notSwappedPosts : appPostAdapter.init(),
      followers : appUserAdapter.init(),
      followeds : appUserAdapter.init()
    })),state)
  ),
  on(
    nextPostsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        posts : appPostAdapter.addMany( action.payload, state.entities[action.userId]!.posts)
      }
    },state)
  ),
  on(
    nextSwappedPostsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        swappedPosts : appPostAdapter.addMany( action.payload, state.entities[action.userId]!.swappedPosts)
      }
    },state)
  ),
  on(
    nextNotSwappedPostsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        notSwappedPosts : appPostAdapter.addMany( action.payload,state.entities[action.userId]!.notSwappedPosts)
      }
    },state)
  ),
  on(
    nextFollowersSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        followers : appUserAdapter.addMany( action.payload, state.entities[action.userId]!.followers)
      }
    },state)
  ),
  on(
    nextFollowedsSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        followeds : appUserAdapter.addMany( action.payload,state.entities[action.userId]!.followeds )
      }
    },state)
  ),
)
