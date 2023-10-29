import { createAction, props } from "@ngrx/store";
import { AddComment } from "src/app/models/requests/add-comment";
import { CommentResponse } from "src/app/models/responses/comment-response";
import { PostResponse } from "src/app/models/responses/post-response";
import { UserResponse } from "src/app/models/responses/user-response";

export const nextPageOfPosts = createAction( "next page of posts");
export const nextPageOfPostsSuccess = createAction( "next page of posts success",props<{posts : PostResponse[]}>() );
export const setSelectedPostId = createAction("set selected post",props<{postId : string}>());
export const resetPageOfPosts = createAction("reset page of posts");

export const nextPageOfPostLikers = createAction("next page of post likers")
export const nextPageOfPostLikersSuccess = createAction("next page of post likers success",props<{likers : UserResponse[]}>())
export const likePost = createAction('like post',props<{postId : string}>())
export const likePostSuccess = createAction('like post success',props<{user : UserResponse}>())

export const nextPageOfComments = createAction("next page of comments");
export const nextPageOfCommentsSuccess = createAction("next page of comments success",props<{comments : CommentResponse[]}>());
export const addComment = createAction("add comment",props<{comment : AddComment}>())
export const addCommentSuccess = createAction("add comment success",props<{comment : CommentResponse}>());
export const setSelectedCommentId = createAction("set selected comment id",props<{commentId : string}>());

export const nextPageOfChildren = createAction("next page of children");
export const nextPageOfChildrenSuccess = createAction("next page of children success",props<{comments : CommentResponse[]}>());
export const addChildCommentSuccess = createAction("add child comment success")
