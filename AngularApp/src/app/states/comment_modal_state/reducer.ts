import { createReducer, on } from "@ngrx/store";
import { add, initCommentModalStates, initialState, loadChildren, loadComments, resetCommentToReply, setCommentToReply, switchVisibility } from "./state";
import { initCommentModalStatesAction, nextPageOfChildrenSuccess, nextPageOfCommentsSuccess, resetCommentToReplyAction, setCommentToReplyAction, shareCommentSuccess, switchVisibilityAction } from "./action";

export const commentModalCollectionReducer = createReducer(
    initialState,
    on(
        shareCommentSuccess,
        (state,action) => add(action.response,action.postId,state)
    ),
    on(
        nextPageOfCommentsSuccess,
        (state,action) => loadComments(action.payload,action.postId,state)
    ),
    on(
        nextPageOfChildrenSuccess,
        (state,action) => loadChildren(action.payload,action.postId,action.commentId,state)
    ),
    on(
        switchVisibilityAction,
        (state,action) => switchVisibility(action.postId,action.commentId,state)

    ),
    on(
        setCommentToReplyAction,
        (state,action) => setCommentToReply(action.postId,action.ownerId,action.ownerType,action.comment,state)
    ),
    on(
        resetCommentToReplyAction,
        (state,action) => resetCommentToReply(action.postId,state)
    ),
    on(
        initCommentModalStatesAction,
        (state,action) => initCommentModalStates(action.postIds,state)
    )
)