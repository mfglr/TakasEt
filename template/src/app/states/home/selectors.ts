import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomeState } from "./states";
import { adapter } from "./adapter";


export const selectHomeState = createFeatureSelector<HomeState>("homeStoreSlice")
const selectPostsStates = createSelector(selectHomeState,adapter.getSelectors().selectAll)
export const selectPosts = createSelector(selectPostsStates,(states) => states.map(x => x.post))
export const selectCurrentPageOfPosts = createSelector(selectHomeState,(state) => state.page);
export const selectStatusOfPosts = createSelector(selectHomeState,(state : HomeState) => state.status);
export const selectSelectedPostId = createSelector(selectHomeState,(state : HomeState) => state.selectedId);
export const selectSelectedPostState = createSelector(
  selectHomeState,
  (state : HomeState) => {
    if(state.selectedId)
      return state.entities[state.selectedId]
    return undefined;
  }
)

export const selectComments = createSelector(selectSelectedPostState,state => state?.comments.entities.map(x => x.comment))
export const selectCurrentPageOfComments = createSelector(selectSelectedPostState,state => state?.comments.page)
export const selectStatusOfComments = createSelector(selectSelectedPostState,state => state?.comments.status)
export const selectSelectedCommentId = createSelector(selectSelectedPostState,(state) => state?.comments.selectedId)
export const selectSelectedCommentState = createSelector(
  selectSelectedPostState,
  state => {
    if(state && state.comments.selectedId){
      let index = state.comments.entities.findIndex(x => x.comment.id == state.comments.selectedId)
      return state.comments.entities[index];
    }
    return undefined;
  }
)
export const selectChildren = createSelector(selectSelectedCommentState,state => state?.children.entities.map(x => x.comment))
