import { createReducer, on } from "@ngrx/store";
import * as appPostState from "./state";
import * as appPostAction from "./actions";

export const appPostReducer = createReducer(
    appPostState.initialState,
    on(appPostAction.nextPageOfPostsSuccess,(state,action) =>({
        ...state,
        parentState : appPostState.loadPosts(action.posts,action.queryId,state.parentState)
    })),
    on(appPostAction.setSelectedQueryId,(state,action) => ({ ...state, selectedQueryId : action.queryId }))
) 