import { createReducer, on } from "@ngrx/store";
import { addComment, initialState, loadComments } from "./state";
import { addSuccessAction, nextPageSuccessAction } from "./actions";

export const appCommentReducer = createReducer(
    initialState,
    on(
        nextPageSuccessAction,
        (state,action) => ({ ...state,parentState : loadComments(action.payload,action.postId,state.parentState) })
    ),
    on(
        addSuccessAction,
        (state,action) => ({...state,parentState : addComment(action.payload,state.parentState)})
    )
)