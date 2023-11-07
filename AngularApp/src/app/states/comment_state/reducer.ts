import { createReducer, on } from "@ngrx/store";
import { initialState, loadComments } from "./state";
import { nextPageSuccessAction } from "./actions";

export const appCommentReducer = createReducer(
    initialState,
    on(
        nextPageSuccessAction,
        (state,action) => ({ ...state,parentState : loadComments(action.payload,action.postId,state.parentState) })
    )
)