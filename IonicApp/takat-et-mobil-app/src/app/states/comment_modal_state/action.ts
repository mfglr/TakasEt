import { createAction, props } from "@ngrx/store";
import { CommentResponse } from "src/app/models/responses/comment-response";

export const shareComment = createAction(
    "[comment_modal_state] shareComment",
    props<{postId : number,content : string }>()
)
export const shareCommentSuccess = createAction(
    "[comment_modal_state] shareCommentSuccess",
    props<{postId : number,response : CommentResponse}>()
)
export const nextPageOfComments = createAction("[comment_modal_state] nextPageOfComments",props<{postId : number}>());
export const nextPageOfCommentsSuccess = createAction(
    "[comment_modal_state] nextPageOfCommentsSuccess",
    props<{postId : number,payload : CommentResponse[]}>()
);
export const nextPageOfChildren = createAction(
    "[comment_modal_state] nextPageOfChildren",
    props<{postId : number,commentId : number}>()
);
export const nextPageOfChildrenSuccess = createAction(
    "[comment_modal_state] nextPageOfChildrenSuccess",
    props<{postId : number,commentId : number,payload : CommentResponse[]}>()
);
export const switchVisibilityAction = createAction(
    "[comment_modal_state] switchVisibility",
    props<{postId : number,commentId : number}>()
);
export const setCommentToReplyAction = createAction(
    "[comment_modal_state] setCommentToReply",
    props<{postId : number, ownerId : number,ownerType : "post" | "comment",comment : CommentResponse}>()
)
export const resetCommentToReplyAction = createAction(
    "[comment_modal_state] resetCommentToReply",
    props<{postId : number}>()
)
export const initCommentModalStatesAction = createAction(
    "[comment_modal_state] initCommentModalStatesAction",
    props<{postIds : number[]}>()
) 