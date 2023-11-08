import { createReducer, on } from "@ngrx/store";
import { addSuccessAction, nextPageActionSuccess, switchVisibilityAction } from "./actions";
import { addComment, initialState, loadComments, switchVisibility } from "./state";

export const appChildCommentReducer = createReducer(
    initialState,
    on(
        nextPageActionSuccess,
        (state,action) => ({...state,parentState : loadComments(action.payload,action.parentComment,state.parentState)})
    ),
    on(
        switchVisibilityAction,
        (state, action) => ({...state,parentState : switchVisibility(action.parentComentId,state.parentState)})
    ),
    on(
        addSuccessAction,
        (state,action) => ({...state,parentState : addComment(action.payload,action.parentComment,state.parentState)})
    )
)