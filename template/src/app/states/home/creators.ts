import { CommentState, CommentsState, PostState, UserState } from "./states"
import { UserResponse } from "src/app/models/responses/user-response"
import { CommentResponse } from "src/app/models/responses/comment-response"
import { initialPageOfComments, initialPageOfPosts, initialPageOfUsers } from "../state"
import { PostResponse } from "src/app/models/responses/post-response"
import { adapterOfChildren, adapterOfComments, adapterOfUsersLiked, adapterOfUsersVeiwed } from "./adapters"
import { EntityAdapter, createEntityAdapter } from "@ngrx/entity"

export class Handler{

}


export const homeAdapter : EntityAdapter<PostState> = createEntityAdapter<PostState>({
  selectId : state => state.post.id
})
export const commentAdapeters : EntityAdapter<CommentState>[] = [];
export const childAdapters : EntityAdapter<CommentState>[] = [];

function createCommentState( commentResponse : CommentResponse) : CommentState{
  return {
    comment : commentResponse,
    children : adapterOfChildren.getInitialState({
      status : false,
      page : {...initialPageOfComments},
      selectedId : undefined
    }),
  };
}
export function createCommentStates( commentResponses : CommentResponse[]) : CommentState[]{
  return commentResponses.map(x => createCommentState(x));
}
function createUserState( userResponse : UserResponse ) : UserState{
  return { user : userResponse }
}
export function createUserStates(userResponses : UserResponse[]) : UserState[]{
  return userResponses.map(x => createUserState(x));
}
function createPostState(postResponse : PostResponse) : PostState{
  return {
    post : postResponse,
    comments : adapterOfComments.getInitialState({
      status : false,
      page : {...initialPageOfPosts},
      selectedId : undefined
    }),
    usersLiked : adapterOfUsersLiked.getInitialState({
      selectedId : undefined,
      status : false,
      page : {...initialPageOfUsers},
    }),
    usersViewed : adapterOfUsersVeiwed.getInitialState({
      selectedId : undefined,
      status : false,
      page : {...initialPageOfUsers}
    })
  }
}
export function createPostStates(postResponses : PostResponse[]) : PostState[]{
  return postResponses.map(x => createPostState(x));
}
