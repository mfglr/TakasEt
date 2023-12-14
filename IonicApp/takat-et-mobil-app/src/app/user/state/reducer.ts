import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany, init } from "src/app/states/app-entity-state";
import { takeValueOfPosts } from "src/app/states/app-states";
import { initUserModuleAction, nextNotSwappedPostsSuccessAction, nextPostsSuccessAction, nextSwappedPostsSuccessAction } from "./actions";

interface UserModuleState{
  userId : number;
  posts : AppEntityState;
  swappedPosts : AppEntityState;
  notSwappedPosts : AppEntityState;
}
export interface UserModuleCollectionState extends EntityState<UserModuleState>{}

const adapter = createEntityAdapter<UserModuleState>({
  selectId : x => x.userId
})

export const userModuleCollectionReducer = createReducer(
  adapter.getInitialState(),
  on(
    initUserModuleAction,
    (state,action) => adapter.addOne({
      userId : action.userId,
      posts : init(takeValueOfPosts),
      swappedPosts : init(takeValueOfPosts),
      notSwappedPosts : init(takeValueOfPosts)
    },state)
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
  )

)
