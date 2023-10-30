import { createEntityAdapter } from "@ngrx/entity";
import { CommentState, CommentsState, PostImageState, PostImagesState, PostState, PostsState, UserState, UsersState, initialPageOfComments, initialPageOfPostImages, initialPageOfPosts, initialPageOfUsers } from "./app-states";
import { CommentResponse } from "../models/responses/comment-response";
import { PostResponse } from "../models/responses/post-response";
import { UserResponse } from "../models/responses/user-response";

export const commentAdapter = createEntityAdapter<CommentState>({
  selectId : state => state.comment.id
})
export const postAdapter = createEntityAdapter<PostState>({
  selectId : state => state.post.id
})
export const userAdapter = createEntityAdapter<UserState>({
  selectId : state => state.user.id
})
export const postImageAdapter = createEntityAdapter<PostImageState>()

export const selectAllPostStates = postAdapter.getSelectors((state : PostsState) => state).selectAll
export const selectAllCommentStates = commentAdapter.getSelectors((state : CommentsState) => state).selectAll
export const selectAllUserStates = userAdapter.getSelectors((state : UsersState) => state).selectAll
export const selectAllPostImageStates = postImageAdapter.getSelectors((state : PostImagesState) => state).selectAll

export function createCommentState(commentReponse : CommentResponse) : CommentState{
  return {
    comment : commentReponse,
    likers : userAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    children : commentAdapter.getInitialState({
      status : false,
      page : {...initialPageOfComments}
    })
  }
}
export function createCommentStates(commentResponses : CommentResponse[]) : CommentState[]{
  return commentResponses.map(x => createCommentState(x));
}
export function createUserState(userResponse : UserResponse) : UserState{
  return {
    user : userResponse,
    followeds : userAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    followers : userAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    posts : postAdapter.getInitialState({
      page : {...initialPageOfPosts},
      status : false
    })
  }
}
export function createUserStates(userResponses : UserResponse[]) : UserState[]{
  return userResponses.map(x => createUserState(x));
}
export function createPostState(postResponse : PostResponse) : PostState{
  return {
    post : postResponse,
    postImages : postImageAdapter.getInitialState({
      status : false,
      page : {...initialPageOfPostImages}
    }),
    comments : commentAdapter.getInitialState({
      status : false,
      page : {...initialPageOfComments}
    }),
    followers : userAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    likers : userAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    requesteds : postAdapter.getInitialState({
      page : {...initialPageOfPosts},
      status : false
    }),
    requesters : postAdapter.getInitialState({
      page : {...initialPageOfPosts},
      status : false
    }),
    viewers : userAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    })
  }
}
export function createPostStates(postResponses : PostResponse[]) : PostState[]{
  return postResponses.map(x => createPostState(x));
}
