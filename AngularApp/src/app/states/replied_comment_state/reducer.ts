import { createReducer, on } from "@ngrx/store";
import { RepliedCommentState } from "./state";
import { resetAction, setAction } from "./actions";

const initialState : RepliedCommentState = {
    comment : undefined,
    parentComment : undefined,
    userName : undefined,
    status : false
}
export const repliedCommentReducer = createReducer(
    initialState,
    on( 
        setAction,
        (state,action) => ({
            ...state,comment : action.comment,parentComment : action.parentComment,userName : action.userName,status : true
        })
    ),
    on(resetAction,(state) => ({...state,comment : undefined,parentComment : undefined,status : false})),
)