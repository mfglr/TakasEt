import { createReducer, on } from "@ngrx/store";
import { takeValueOfPosts } from "src/app/states/app-states";
import { changeActiveTabAction, nextPostsSuccessAction } from "./actions";
import { AppEntityState, addMany, init } from "src/app/states/app-entity-state";

export interface ProfilePageState{
    posts : AppEntityState;
    activeTab : number;
}

const initialState : ProfilePageState = {
    posts : init(takeValueOfPosts),
    activeTab : 0
}

export const profilePageReducer = createReducer(
    initialState,
    on( changeActiveTabAction, (state,action) => ({ ...state, activeTab : action.activeTab }) ),
    on(
      nextPostsSuccessAction,
      (state,action) => ({
          ...state,
          posts : addMany(
            action.payload.map(x => x.id),
            takeValueOfPosts,
            state.posts
          )
      })
    )
)
