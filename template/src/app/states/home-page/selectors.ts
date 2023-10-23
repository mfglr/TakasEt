import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomePageState } from "./reducer";
import { commentAdapter, postAdapter } from "../app-adapters";
import { CommentsState } from "../app-states";

//HomePageState Selectors;
export const selectHomePageState = createFeatureSelector<HomePageState>("homePageStoreSlice");
export const selectSelectedPostId = createSelector(selectHomePageState,state => state.selectedPostId);
export const selectSelectedCommentId = createSelector(selectHomePageState,state => state.selectedCommentId);

//HomePageState => posts Selectors;
const selectPostsOfHomePageState = createSelector(selectHomePageState,state => state.posts)
const selectPostStatesOfPosts = createSelector(selectPostsOfHomePageState,postAdapter.getSelectors().selectAll)
export const selectPostReponses = createSelector(selectPostStatesOfPosts,state => state.map(x => x.post))
export const selectPageOfPosts = createSelector(selectPostsOfHomePageState,state => state.page)
export const selectStatusOfPosts = createSelector(selectPostsOfHomePageState,state=> state.status)

//HomePageState => posts => Selected PostState => comments Selectors
const selectCommentsOfSelectedPostState = createSelector(
  selectHomePageState,
  state => {
    if(state.selectedPostId)
      return state.posts.entities[state.selectedPostId]?.comments
    return undefined;
  }
)
export const selectPageOfCommentsOfSelectedPostState = createSelector(selectCommentsOfSelectedPostState,state => state?.page)
export const selectStatusOfCommentsOfSelectedPostState = createSelector(selectCommentsOfSelectedPostState,state => state?.status)

//HomePageState => posts => Any PostState => comments Selectors
const selectCommentsOfPostState = (props : {postId : string} ) => createSelector(
  selectHomePageState,
  state => state.posts.entities[props.postId]?.comments
)
const selectCommentStatesOfCommentsOfPostsState = (props : {postId : string} ) => createSelector(
  selectCommentsOfPostState(props),
  commentAdapter.getSelectors(
    (state : CommentsState | undefined) => state ? state : commentAdapter.getInitialState()
  ).selectAll
)
export const selectCommentResponsesOfPostReponse = (props : {postId : string} ) => createSelector(
  selectCommentStatesOfCommentsOfPostsState(props),
  state => state.map(x => x.comment)
)
//HomePageState => posts => Any PostState => comments => Any CommentState => Children Selector
const selectChildrenOfCommentState = (props : {postId : string,commentId : string}) => createSelector(
  selectCommentsOfPostState(props),
  state => state?.entities[props.commentId]?.children
)
const selectCommentStatesOfChildrenOfCommentState = (props : {postId : string,commentId : string}) => createSelector(
  selectChildrenOfCommentState(props),
  commentAdapter.getSelectors(
    (state : CommentsState | undefined) => state ? state : commentAdapter.getInitialState()
  ).selectAll
)
export const selectCommentReponsesOfCommentResponse = (props : {postId : string,commentId : string}) => createSelector(
  selectCommentStatesOfChildrenOfCommentState(props),
  state => state.map(x => x.comment)
)
//HomePageState => posts => Any PostState => comments => Selected CommentState => Children Selector
const selectCommentsOfSelectedCommentState = createSelector(
  selectHomePageState,
  state => {
    if(state.selectedPostId && state.selectedCommentId)
      return state.posts.entities[state.selectedPostId]?.comments.entities[state.selectedCommentId]?.children
    return undefined;
  }
)
export const selectPageOfCommentsOfSelectedCommentState = createSelector(
  selectCommentsOfSelectedCommentState,
  state => state?.page
)
export const selectStatusOfCommentsOfSelectedCommentState = createSelector(
  selectCommentsOfSelectedCommentState,
  state => state?.status
)


