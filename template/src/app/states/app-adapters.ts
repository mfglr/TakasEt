import { createEntityAdapter } from "@ngrx/entity";
import { CommentState, CommentsState, PostState, UserState, UsersState, initialPageOfComments, initialPageOfPosts, initialPageOfUsers } from "./app-states";
import { CommentResponse } from "../models/responses/comment-response";
import { PostResponse } from "../models/responses/post-response";
import { UserResponse } from "../models/responses/user-response";

//comment state
export const commentChildrenAdapter = createEntityAdapter<CommentState>({
  selectId : state => state.comment.id
})
export const commentLikesAdapter = createEntityAdapter<UserState>({
  selectId : state => state.user.id
})

//user state
export const userPostsAdapter = createEntityAdapter<PostState>({
  selectId : state => state.post.id
})
export const userFollowersAdapter = createEntityAdapter<UserState>({
  selectId : state => state.user.id
})
export const userFollowedsAdapter = createEntityAdapter<UserState>({
  selectId : state => state.user.id
})

//post state
export const postCommentsAdapter = createEntityAdapter<CommentState>({
  selectId : state => state.comment.id
})
export const postLikesAdapter = createEntityAdapter<UserState>({
  selectId : state => state.user.id
})
export const postViewsAdapter = createEntityAdapter<UserState>({
  selectId : state => state.user.id
})
export const postRequestersAdapter = createEntityAdapter<PostState>({
  selectId : state => state.post.id
})
export const postRequestedsAdapter = createEntityAdapter<PostState>({
  selectId : state => state.post.id
})
export const postFollowersAdapter = createEntityAdapter<UserState>({
  selectId : state => state.user.id
})

export const commentAdapter = createEntityAdapter<CommentState>({
  selectId : state => state.comment.id
})
export const postAdapter = createEntityAdapter<PostState>({
  selectId : state => state.post.id
})
export const userAdapter = createEntityAdapter<UserState>({
  selectId : state => state.user.id
})

function createCommentState(commentReponse : CommentResponse) : CommentState{
  return {
    comment : commentReponse,
    likes : commentLikesAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    children : commentChildrenAdapter.getInitialState({
      status : false,
      page : {...initialPageOfComments}
    })
  }
}
export function createCommentStates(commentResponses : CommentResponse[]) : CommentState[]{
  return commentResponses.map(x => createCommentState(x));
}
function createUserState(userResponse : UserResponse) : UserState{
  return {
    user : userResponse,
    followedsState : userFollowedsAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    followersState : userFollowersAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    postsState : userPostsAdapter.getInitialState({
      page : {...initialPageOfPosts},
      status : false
    })
  }
}
export function createUserStates(userResponses : UserResponse[]) : UserState[]{
  return userResponses.map(x => createUserState(x));
}
function createPostState(postResponse : PostResponse) : PostState{
  return {
    post : postResponse,
    comments : postCommentsAdapter.getInitialState({
      status : false,
      page : {...initialPageOfComments}
    }),
    followers : postFollowersAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    likes : postLikesAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    }),
    requesteds : postRequestedsAdapter.getInitialState({
      page : {...initialPageOfPosts},
      status : false
    }),
    requesters : postRequestersAdapter.getInitialState({
      page : {...initialPageOfPosts},
      status : false
    }),
    views : postViewsAdapter.getInitialState({
      page : {...initialPageOfUsers},
      status : false
    })
  }
}
export function createPostStates(postResponses : PostResponse[]) : PostState[]{
  return postResponses.map(x => createPostState(x));
}
