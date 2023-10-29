import { createFeatureSelector, createSelector } from "@ngrx/store";
import { HomePageState } from "../reducer";
import { postAdapter } from "../../app-adapters";

//HomePageState Selectors;
export const selectHomePageState = createFeatureSelector<HomePageState>("homePageStoreSlice");
export const selectSelectedPostId = createSelector(selectHomePageState,state => state.selectedPostId);
export const selectSelectedCommentId = createSelector(selectHomePageState,state => state.selectedCommentId);

//HomePageState => posts Selectors;
export const selectPostsState = createSelector(selectHomePageState,state => state.posts)
const selectPostStates = createSelector(selectPostsState,postAdapter.getSelectors().selectAll)
export const selectPostReponsesOfHomePage = createSelector(selectPostStates,state => state.map(x => x.post))
export const selectPageOfHomePagePosts = createSelector(selectPostsState,state => state.page)
export const selectStatusOfHomePagePosts = createSelector(selectPostsState,state=> state.status)
