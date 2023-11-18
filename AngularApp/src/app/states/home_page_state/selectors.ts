import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppEntityState } from "../app-states";
import { HomePageState, PostState, noImageUrl, postStateAdapter } from "./state";

const selectHomePageState = createFeatureSelector<HomePageState>("HomePageState");
const selectPosts = createSelector(selectHomePageState,(state : HomePageState ) => state.posts)

export const selectPostResponses = createSelector(
    selectPosts,
    state => postStateAdapter.getSelectors((state : AppEntityState<PostState>) => state).selectAll(state).map(x => x.post)
)
export const selectPageOfPosts = createSelector( selectPosts, state => state.page )
export const selectStatusOfPosts = createSelector( selectPosts, state => state.status )
export const selectPostImageId = (props : {postId : number,index : number}) => createSelector(
    selectPosts,
    state => state.entities[props.postId]!.post.postImages[props.index].id
)
const selectImageState = (props : {postId : number}) => createSelector(
    selectPosts,
    state => state.entities[props.postId]!.urls
)
export const selectUrls = (props : {postId : number}) => createSelector(
    selectImageState(props),
    state => state.map(x => x.url)
)
export const selectUrl = (props : {postId : number,index : number}) => createSelector(
    selectUrls(props),
    state => state[props.index]
)
export const selectCurrentIndex = (props : {postId : number}) => createSelector(
    selectPosts,
    state => state.entities[props.postId]!.currentIndex
)
export const selectIsLoad = (props : {postId : number,index : number}) => createSelector(
    selectImageState(props),
    state => state[props.index].isLoad
)
