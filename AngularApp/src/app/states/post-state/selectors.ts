import { createFeatureSelector, createSelector } from "@ngrx/store";
import { PagePostState, entityPostAdapter } from "./state";

const selectPagePost = createFeatureSelector<PagePostState>("PagePostStore");
export const selectPosts = (props : {pageId : string}) => createSelector(
    selectPagePost,
    state => state.entities[props.pageId]!
)
export const selectPostResponses = (props : { pageId : string}) => createSelector(
    selectPosts(props),
    state => entityPostAdapter.getSelectors().selectAll(state).map(x => x.post)
)
export const selectPageOfPosts = (props : { pageId : string }) => createSelector(
    selectPosts(props),
    state => state.page
)
export const selectStatusOfPosts = (props : { pageId : string }) => createSelector(
    selectPosts(props),
    state => state.status
)
export const selectPostImageId = (props : {pageId : string, postId : number, index : number}) => createSelector(
    selectPosts(props),
    state => state.entities[props.postId]!.post.postImages[props.index].id
)

const selectPostImageState = (props : {pageId : string, postId : number}) => createSelector(
    selectPosts(props),
    state => state.entities[props.postId]!.postImages
)
const selectProfileImageState = (props : {pageId : string, postId : number}) => createSelector(
    selectPosts(props),
    state => state.entities[props.postId]!.profileImage
)
export const selectUrls = (props : {pageId : string, postId : number}) => createSelector(
    selectPostImageState(props),
    state => state.map(x => x.url)
)
export const selectUrl = (props : {pageId : string, postId : number, index : number}) => createSelector(
    selectUrls(props),
    state => state[props.index]
)
export const selectCurrentPostImageIndex = (props : {pageId : string, postId : number}) => createSelector(
    selectPosts(props),
    state => state.entities[props.postId]!.currentPostImageIndex
)
export const selectPostImageStatus = (props : {pageId : string, postId : number, index : number}) => createSelector(
    selectPostImageState(props),
    state => state[props.index].isLoad
)
export const selectProfileImageStatus = (props : {pageId : string, postId : number}) => createSelector(
    selectProfileImageState(props),
    state => state.isLoad
)
export const selectProfileImageId = (props : {pageId : string, postId : number}) => createSelector(
    selectPosts(props),
    state => state.entities[props.postId]!.post.profileImage.id
)
export const selectProfileImage = (props : {pageId : string, postId : number}) => createSelector(
    selectProfileImageState(props),
    state => state.url
)