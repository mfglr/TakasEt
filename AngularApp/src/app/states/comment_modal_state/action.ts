import { createAction, props } from "@ngrx/store";
import { AddComment } from "src/app/models/requests/add-comment";
import { CommentResponse } from "src/app/models/responses/comment-response";

export const shareComment = createAction(
    "[comment_modal_state] shareComment",
    props<{postId : string,content : string }>()
)
export const shareCommentSuccess = createAction(
    "[comment_modal_state] shareCommentSuccess",
    props<{postId : string,response : CommentResponse}>()
)
export const nextPageOfComments = createAction("[comment_modal_state] nextPageOfComments",props<{postId : string}>());
export const nextPageOfCommentsSuccess = createAction(
    "[comment_modal_state] nextPageOfCommentsSuccess",
    props<{postId : string,payload : CommentResponse[]}>()
);
export const nextPageOfChildren = createAction(
    "[comment_modal_state] nextPageOfChildren",
    props<{postId : string,commentId : string}>()
);
export const nextPageOfChildrenSuccess = createAction(
    "[comment_modal_state] nextPageOfChildrenSuccess",
    props<{postId : string,commentId : string,payload : CommentResponse[]}>()
);
export const switchVisibilityAction = createAction(
    "[comment_modal_state] switchVisibility",
    props<{postId : string,commentId : string}>()
);
export const setCommentToReplyAction = createAction(
    "[comment_modal_state] setCommentToReply",
    props<{postId : string, ownerId : string,ownerType : "post" | "comment",comment : CommentResponse}>()
)
export const resetCommentToReplyAction = createAction(
    "[comment_modal_state] resetCommentToReply",
    props<{postId : string}>()
)
export const initCommentModalStatesAction = createAction(
    "[comment_modal_state] initCommentModalStatesAction",
    props<{postIds : string[]}>()
) 