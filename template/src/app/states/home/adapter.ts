import { CommentState, PostState, UserState } from "./states"
import { UserResponse } from "src/app/models/responses/user-response"
import { CommentResponse } from "src/app/models/responses/comment-response"
import { initialPageOfComments, initialPageOfUsers } from "../app-state"
import { PostResponse } from "src/app/models/responses/post-response"
import { createEntityAdapter } from "@ngrx/entity"

export const adapter = createEntityAdapter<PostState>({
  selectId : (state) => state.post.id
})

function createCommentState( commentResponse : CommentResponse) : CommentState{
  return {
    comment : commentResponse,
    children : {
      entities : [],
      status : false,
      page : {...initialPageOfComments},
      selectedId : undefined
    },
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
    comments : {
      entities : [],
      status : false,
      page : {...initialPageOfComments},
      selectedId : undefined
    },
    usersLiked : {
      entities : [],
      selectedId : undefined,
      status : false,
      page : {...initialPageOfUsers},
    },
    usersViewed : {
      entities:[],
      selectedId : undefined,
      status : false,
      page : {...initialPageOfUsers}
    }
  }
}
export function createPostStates(postResponses : PostResponse[]) : PostState[]{
  return postResponses.map(x => createPostState(x));
}
