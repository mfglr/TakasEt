import { createReducer, on } from "@ngrx/store";
import * as appCommnetState from "./state";
import * as appCommentActions from "./actions";

export const appCommentReducer = createReducer(
    appCommnetState.initialState,
    on(
        appCommentActions.nextPageOfCommentsSuccess,
        (state,action) => ({ ...state,parentState : appCommnetState.loadComments(action.payload,action.queryId,state.parentState) })
    ),
    on(
        appCommentActions.switchChildrenVisibility,
        (state,action) => ({
            ...state,
            parentState : appCommnetState.switchChildrenVisibility(action.queryId,action.parentCommentId,state.parentState)
        })
    )
)