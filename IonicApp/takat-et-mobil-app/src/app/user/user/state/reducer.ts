import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { takeValueOfPosts } from "src/app/states/app-states";
import { changeActiveTabAction, initUserPageStateAction, nextPostsSuccessAction } from "./actions";
import { AppEntityState, addMany, init } from "src/app/states/app-entity-state";

interface UserPageState{
  userId : number;
  posts : AppEntityState;
  activeTab : number;
}
export interface State extends EntityState<UserPageState>{}

const adapter = createEntityAdapter<UserPageState>({
  selectId : x => x.userId
})

export const userPageReducer = createReducer(
  adapter.getInitialState(),
  on(
    changeActiveTabAction,
    (state,action) => adapter.updateOne({ id : action.userId, changes : { activeTab : action.activeTab } },state)
  ),
  on(
    initUserPageStateAction,
    (state,action) => adapter.addOne({
      userId : action.userId,
      activeTab : 0,
      posts : init(takeValueOfPosts)
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
  )
)
