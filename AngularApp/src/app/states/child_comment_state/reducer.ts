import { createReducer, on } from "@ngrx/store";
import { addSuccessAction, nextPageActionSuccess, setVisibileAction, switchVisibilityAction } from "./actions";
import { addComment, initialState, loadComments, setVisibile, switchVisibility } from "./state";

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
        setVisibileAction,
        (state,action) => ({...state,parentState : setVisibile(action.parentCommentId,state.parentState)})
    ),
    on(
        addSuccessAction,
        (state,action) => ({...state,parentState : addComment(action.payload,action.parentComment,state.parentState)})
    )
)