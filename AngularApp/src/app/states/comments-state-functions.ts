import { CommentResponse } from "../models/responses/comment-response"
import { UserResponse } from "../models/responses/user-response"
import { commentAdapter, createCommentState, createCommentStates, createUserState, createUserStates, userAdapter } from "./app-adapters"
import { CommentsState, takeValueOfComments, takeValueOfUsers } from "./app-states"

export class CommentsStateFunctions{

  static addLiker(state : CommentsState, user : UserResponse,commentId : string) : CommentsState{
    return commentAdapter.updateOne({
      id : commentId,
      changes : { likers : userAdapter.addOne(createUserState(user),state.entities[commentId]!.likers) }
    },state)
  }
  static removeLiker(state : CommentsState,userId : string,commentId : string) : CommentsState{
    return commentAdapter.updateOne({
      id : commentId,
      changes : { likers : userAdapter.removeOne(userId,state.entities[commentId]!.likers)}
    },state)
  }
  static loadLikers(state : CommentsState,users : UserResponse[],commentId : string){
    let likers = state.entities[commentId]!.likers;
    return commentAdapter.updateOne({
      id : commentId,
      changes : {
        likers : {
          ...userAdapter.addMany(createUserStates(users),likers),
          status : users.length < takeValueOfUsers,
          page : {...likers.page,skip : likers.page.skip + takeValueOfUsers}
        }
      }
    },state)
  }

  static addChildComment(state : CommentsState,comment : CommentResponse,parentCommentId : string) : CommentsState{
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : { children : commentAdapter.addOne(createCommentState(comment),state.entities[parentCommentId]!.children)}
    },state)
  }
  static removeChildComment(state : CommentsState,commentId : string, parentCommentId : string) : CommentsState{
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : { children : commentAdapter.removeOne(commentId,state.entities[parentCommentId]!.children) }
    },state)
  }
  static loadChildComments(state : CommentsState,comments : CommentResponse[],parentCommentId : string) : CommentsState{
    let children = state.entities[parentCommentId]!.children;
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : {
        children : {
          ...commentAdapter.addMany(createCommentStates(comments),children),
          status : comments.length < takeValueOfComments,
          page : { ...children.page, skip : children.page.skip + takeValueOfComments }
        }
      }
    },state)
  }

  static addChildCommentLiker(state : CommentsState,user : UserResponse,parentCommentId : string,childCommentId : string){
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : { children : this.addLiker(state.entities[parentCommentId]!.children,user,childCommentId) }
    },state)
  }
  static removeChildCommentLiker(state : CommentsState,userId : string,parentCommentId : string,childCommentId : string){
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : { children : this.removeLiker(state.entities[parentCommentId]!.children,userId,childCommentId) }
    },state)
  }
  static loadChildCommentLikers(state : CommentsState,users : UserResponse[],parentCommentId : string,childCommentId : string){
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : { children : this.loadLikers(state.entities[parentCommentId]!.children,users,childCommentId) }
    },state)
  }

}
