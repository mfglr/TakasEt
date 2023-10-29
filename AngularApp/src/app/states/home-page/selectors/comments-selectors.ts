import { createSelector } from "@ngrx/store";
import { commentAdapter, selectAllCommentStates, selectAllUserStates } from "../../app-adapters";
import { CommentsState } from "../../app-states";
import { selectHomePageState } from "./home-page-selectors";
import { CommentResponse } from "src/app/models/responses/comment-response";
import { UserResponse } from "src/app/models/responses/user-response";

const selectSelectedComments = createSelector(
  selectHomePageState,
  state => {
    if(state.selectedPostId)
      return state.posts.entities[state.selectedPostId]?.comments
    return undefined;
  }
)
const selectSelectedCommentStates = createSelector(
  selectSelectedComments,
  commentAdapter.getSelectors(
    (state : CommentsState | undefined) => state ? state : commentAdapter.getInitialState()
  ).selectAll
)

// const selectComments = (props : {postId : string} ) => createSelector(
//   selectHomePageState,
//   state => state.posts.entities[props.postId]?.comments
// )
// const selectCommentStates = (props : {postId : string} ) => createSelector(
//   selectComments(props),
//   commentAdapter.getSelectors(
//     (state : CommentsState | undefined) => state ? state : commentAdapter.getInitialState()
//   ).selectAll
// )
const selectSelectedChildren = createSelector(
  selectHomePageState,
  state => {
    if(state.selectedPostId && state.selectedCommentId)
      return state.posts.entities[state.selectedPostId]?.comments.entities[state.selectedCommentId]?.children
    return undefined;
  }
)
// const selectChildren = (props : {postId : string,commentId : string}) => createSelector(
//   selectComments(props),
//   state => state?.entities[props.commentId]?.children
// )
// const selectCommentStatesOfChildren = (props : {postId : string,commentId : string}) => createSelector(
//   selectChildren(props),
//   commentAdapter.getSelectors(
//     (state : CommentsState | undefined) => state ? state : commentAdapter.getInitialState()
//   ).selectAll
// )
export const selectPageOfComments = createSelector(selectSelectedComments,state => state?.page)
export const selectStatusOfComments = createSelector(selectSelectedComments,state => state?.status)
export const selectSelectedCommentResponses = createSelector(
  selectSelectedCommentStates,
  state => state.map(x => x.comment)
)
// export const selectCommentResponses = (props : {postId : string} ) => createSelector(
//   selectCommentStates(props),
//   state => state.map(x => x.comment)
// )
// export const selectCommentReponsesOfChildren = (props : {postId : string,commentId : string}) => createSelector(
//   selectCommentStatesOfChildren(props),
//   state => state.map(x => x.comment)
// )

export const selectPageOfChildren = createSelector(
  selectSelectedChildren,
  state => state?.page
)
export const selectStatusOfChildren = createSelector(
  selectSelectedChildren,
  state => state?.status
)

export interface MappedCommentStateModel{
  comment : CommentResponse
  likers : UserResponse[]
  children? : MappedCommentStateModel[]
}

export const comments = createSelector(
  selectSelectedCommentStates,
  (state) : MappedCommentStateModel[] => state.map(x => ({
    comment : x.comment,
    likers : selectAllUserStates(x.likers).map(x => x.user),
    children : selectAllCommentStates(x.children).map(x => ({
      comment : x.comment,
      likers : selectAllUserStates(x.likers).map(x => x.user)
    }))
  }))
)
