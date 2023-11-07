import { createReducer, on } from "@ngrx/store";
import { nextPageActionSuccess, switchVisibilityAction } from "./actions";
import { initialState, loadComments, switchVisibility } from "./state";

export const appChildCommentReducer = createReducer(
    initialState,
    on(
        nextPageActionSuccess,
        (state,action) => ({...state,parentState : loadComments(action.payload,action.parentComment,state.parentState)})
    ),
    on(
        switchVisibilityAction,
        (state, action) => ({...state,parentState : switchVisibility(action.parentComentId,state.parentState)})
    )
)