import { CommentsState, PostsState,takeValueOfComments } from "./app-states";
import { commentAdapter, createCommentState, createCommentStates, postAdapter } from "./app-adapters";
import { CommentResponse } from "src/app/models/responses/comment-response";


export class CommentsStateFunctions{
  static addComment(state : CommentsState,comment : CommentResponse) : CommentsState{
    return commentAdapter.addOne(createCommentState(comment),state)
  }
  static removeComment(state : CommentsState,commentId : string) : CommentsState{
    return commentAdapter.removeOne(commentId,state)
  }
  static loadComments(state : CommentsState,comments : CommentResponse[]) : CommentsState{
    return {
      ...commentAdapter.addMany(createCommentStates(comments),state),
      status : comments.length < takeValueOfComments,
      page : { ...state.page, skip : state.page.skip + takeValueOfComments }
    }
  }

  static addChildComment(state : CommentsState,comment : CommentResponse,parentCommentId : string) : CommentsState{
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : { children : this.addComment(state.entities[parentCommentId]!.children,comment)}
    },state)
  }
  static removeChildComment(state : CommentsState,commentId : string, parentCommentId : string) : CommentsState{
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : { children : this.removeComment(state.entities[parentCommentId]!.children,commentId) }
    },state)
  }
  static loadChildComments(state : CommentsState,comments : CommentResponse[],parentCommentId : string) : CommentsState{
    return commentAdapter.updateOne({
      id : parentCommentId,
      changes : { children : this.loadComments(state.entities[parentCommentId]!.children,comments)}
    },state)
  }
}
export class PostsStateFunctions{
  static addComment(state : PostsState,comment : CommentResponse,postId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : {comments : CommentsStateFunctions.addComment(state.entities[postId]!.comments,comment)}
    },state)
  }
  static removeComment(state : PostsState,commentId : string,postId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { comments : CommentsStateFunctions.removeComment(state.entities[postId]!.comments,commentId) }
    },state)
  }
  static loadComments(state : PostsState,comments : CommentResponse[],postId : string) : PostsState{
    return postAdapter.updateOne({
      id : postId,
      changes : { comments : CommentsStateFunctions.loadComments(state.entities[postId]!.comments,comments) }
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
        comments : commentAdapter.updateOne({
          id : parentCommentId,
          changes : {
            children : CommentsStateFunctions.removeComment(children,commentId)
          }
        },comments)
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
}
