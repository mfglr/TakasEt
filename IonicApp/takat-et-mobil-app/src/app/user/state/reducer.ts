import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { AppEntityState, addMany } from "src/app/states/app-entity-state";
import { nextNotSwappedPostsSuccessAction, nextPostsSuccessAction, nextSwappedPostsSuccessAction } from "./actions";
import { takeValueOfPosts } from "src/app/states/app-states";

export interface UserModuleState{
  userId : number;
  posts : AppEntityState;
  swappedPosts : AppEntityState;
  notSwappedPosts : AppEntityState;
}
export interface State extends EntityState<UserModuleState>{}
const adapter = createEntityAdapter<UserModuleState>({selectId : x => x.userId})

export const userModuleReducer = createReducer(
  adapter.getInitialState(),
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
          state.entities[action.userId]!.posts
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
          state.entities[action.userId]!.posts
        )
      }
    },state)
  )

)
