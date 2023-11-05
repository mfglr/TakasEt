import { CommentResponse } from "src/app/models/responses/comment-response";
import { UserResponse } from "../models/responses/user-response";
import { PostsState, takeValueOfComments, takeValueOfPosts, takeValueOfUsers } from "./app_state/app-states";
import { commentAdapter, createCommentState, createCommentStates, createPostState, createPostStates, createUserState, createUserStates, postAdapter, userAdapter } from "./app_state/app-adapters";
import { CommentsStateFunctions } from "./comments-state-functions";
import { PostResponse } from "../models/responses/post-response";

export class PostsStateFunctions{

  static addComment(state : PostsState,comment : CommentResponse,postId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {comments : commentAdapter.addOne(createCommentState(comment),state.entities[postId]!.comments)}
    },state)
  }
  static removeComment(state : PostsState,commentId : string,postId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { comments : commentAdapter.removeOne(commentId,state.entities[postId]!.comments) }
    },state)
  }
  static loadComments(state : PostsState,comments : CommentResponse[],postId : string) : PostsState{
    let commentsState = state.entities[postId]!.comments
    return postAdapter.updateOne({
      id : postId,
      changes : {
        comments : {
          ...commentAdapter.addMany(createCommentStates(comments),commentsState),
          status : comments.length < takeValueOfComments,
          page : { ...commentsState.page, skip : commentsState.page.skip + takeValueOfComments }
        }
      }
    },state)
  }

  static addCommentLiker(state : PostsState,user : UserResponse,postId : string,commentId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {comments : CommentsStateFunctions.addLiker(state.entities[postId]!.comments,user,commentId)}
    },state)
  }
  static removeCommentLiker(state : PostsState,userId : string,postId : string,commentId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {comments : CommentsStateFunctions.removeLiker(state.entities[postId]!.comments,userId,commentId)}
    },state)
  }
  static loadCommentLikers(state : PostsState,users : UserResponse[],postId : string,commentId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {comments : CommentsStateFunctions.loadLikers(state.entities[postId]!.comments,users,commentId)}
    },state)
  }

  static addChildComment(state : PostsState,comment : CommentResponse,postId : string,parentCommentId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { comments : CommentsStateFunctions.addChildComment(state.entities[postId]!.comments,comment,parentCommentId) }
    },state)
  }
  static removeChildComment(state : PostsState,commentId : string,postId : string,parentCommentId : string) : PostsState{
    let comments = state.entities[postId]!.comments;
    let children = comments.entities[parentCommentId!]!.children;
    return postAdapter.updateOne({
      id : postId,
      changes : {
        comments : CommentsStateFunctions.removeChildComment(state.entities[postId]!.comments,commentId,parentCommentId)
      }
    },state)
  }
  static loadChildComments(state : PostsState,comments : CommentResponse[],postId : string,parentCommentId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {
        comments : CommentsStateFunctions.loadChildComments(state.entities[postId]!.comments,comments,parentCommentId)
      }
    },state)
  }

  static addChildCommentLiker(
    state : PostsState,user : UserResponse,postId : string,parentCommentId : string,childCommentId : string
  ) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {
        comments : CommentsStateFunctions.addChildCommentLiker(state.entities[postId]!.comments,user,parentCommentId,childCommentId)
      }
    },state)
  }
  static removeChildCommentLiker(
    state : PostsState,userId: string,postId : string,parentCommentId : string,childCommentId : string
  ) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {
        comments : CommentsStateFunctions.removeChildCommentLiker(state.entities[postId]!.comments,userId,parentCommentId,childCommentId)
      }
    },state)
  }
  static loadChildCommentLiker(
    state : PostsState,users : UserResponse[],postId : string,parentCommentId : string,childCommentId : string
  ) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {
        comments : CommentsStateFunctions.loadChildCommentLikers(state.entities[postId]!.comments,users,parentCommentId,childCommentId)
      }
    },state)
  }

  static addLiker(state : PostsState,user : UserResponse,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { likers : userAdapter.addOne(createUserState(user),state.entities[postId]!.likers)}
    },state)
  }
  static removeLiker(state : PostsState,userId : string,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { likers : userAdapter.removeOne(userId,state.entities[postId]!.likers)}
    },state)
  }
  static loadLikers(state : PostsState,users : UserResponse[],postId : string): PostsState{
    let likers =  state.entities[postId]!.likers
    return postAdapter.updateOne({
      id : postId,
      changes : {
        likers : {
          ...userAdapter.addMany(createUserStates(users),likers),
          status : users.length < takeValueOfUsers,
          page : {...likers.page,skip : likers.page.skip + takeValueOfUsers}
        }
      }
    },state)
  }

  static addViewer(state : PostsState,user : UserResponse,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { viewers : userAdapter.addOne(createUserState(user),state.entities[postId]!.viewers)}
    },state)
  }
  static removeViewer(state : PostsState,userId : string,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { viewers : userAdapter.removeOne(userId,state.entities[postId]!.viewers)}
    },state)
  }
  static loadViewers(state : PostsState,users : UserResponse[],postId : string): PostsState{
    let viewers =  state.entities[postId]!.viewers
    return postAdapter.updateOne({
      id : postId,
      changes : {
        viewers : {
          ...userAdapter.addMany(createUserStates(users),viewers),
          status : users.length < takeValueOfUsers,
          page : {...viewers.page,skip : viewers.page.skip + takeValueOfUsers}
        }
      }
    },state)
  }

  static addFollower(state : PostsState,user : UserResponse,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { followers : userAdapter.addOne(createUserState(user),state.entities[postId]!.followers)}
    },state)
  }
  static removeFollower(state : PostsState,userId : string,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { followers : userAdapter.removeOne(userId,state.entities[postId]!.followers)}
    },state)
  }
  static loadFollowers(state : PostsState,users : UserResponse[],postId : string): PostsState{
    let followers =  state.entities[postId]!.followers
    return postAdapter.updateOne({
      id : postId,
      changes : {
        followers : {
          ...userAdapter.addMany(createUserStates(users),followers),
          status : users.length < takeValueOfUsers,
          page : {...followers.page,skip : followers.page.skip + takeValueOfUsers}
        }
      }
    },state)
  }

  static addRequester(state : PostsState,requesterPost : PostResponse,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { requesters : postAdapter.addOne(createPostState(requesterPost),state.entities[postId]!.requesters)}
    },state)
  }
  static removeRequester(state : PostsState,requesterId : string,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { requesters : postAdapter.removeOne(requesterId,state.entities[postId]!.requesters)}
    },state)
  }
  static loadRequesters(state : PostsState,requesterPosts : PostResponse[],postId : string): PostsState{
    let requesters = state.entities[postId]!.requesters
    return postAdapter.updateOne({
      id : postId,
      changes : {
        requesters : {
          ...postAdapter.addMany(createPostStates(requesterPosts),requesters),
          status : requesterPosts.length < takeValueOfPosts,
          page : {...requesters.page,skip : requesters.page.skip + takeValueOfPosts}
        }
      }
    },state)
  }

  static addRequested(state : PostsState,requestedPost : PostResponse,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { requesteds : postAdapter.addOne(createPostState(requestedPost),state.entities[postId]!.requesteds)}
    },state)
  }
  static removeRequested(state : PostsState,requestedId : string,postId : string): PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { requesteds : postAdapter.removeOne(requestedId,state.entities[postId]!.requesteds)}
    },state)
  }
  static loadRequesteds(state : PostsState,requestedPosts : PostResponse[],postId : string): PostsState{
    let requesteds = state.entities[postId]!.requesteds
    return postAdapter.updateOne({
      id : postId,
      changes : {
        requesteds : {
          ...postAdapter.addMany(createPostStates(requestedPosts),requesteds),
          status : requestedPosts.length < takeValueOfPosts,
          page : {...requesteds.page,skip : requesteds.page.skip + takeValueOfPosts}
        }
      }
    },state)
  }
}
