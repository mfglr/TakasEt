import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomeState } from "./states";
import { adapterOfComments, adapterOfHome } from "./adapters";


const selectHomeState = createFeatureSelector<HomeState>("homeStoreSlice")
export const selectPosts = createSelector(adapterOfHome.getSelectors().selectAll,(states) => states.map(x => x.post))
export const selectCurrentPageOfPosts = createSelector(selectHomeState,(state) => state.page);
export const selectStatusOfPosts = createSelector(selectHomeState,(state : HomeState) => state.status);
export const selectSelectedPostId = createSelector(selectHomeState,(state : HomeState) => state.selectedId);

export const selectComments = createSelector(selectHomeState,state =>{
  let c = state.entities[state.selectedId!]?.comments.entities
})
export const selectStatusOfComments = createSelector(
  selectHomeState,
  (state) => {
    if(state.selectedId && state.entities[state.selectedId])
      return state.entities[state.selectedId]!.comments.status
    return true;
  }
)
export const selectCurrentPageOfComments = createSelector(
  selectHomeState,
  (state) => {
    if(state.selectedId && state.entities[state.selectedId])
      return state.entities[state.selectedId]!.comments.page
    return undefined;
  }
)
