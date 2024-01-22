import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AppState } from "./reducer";
import { appPostAdapter } from "./app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<AppState>("AppStore")
const selectProfileState = createSelector(selectStore,state => state.profileState)
export const selectPosts = createSelector(selectProfileState,state => state.posts)
export const selectPostResponses = createSelector(selectPosts,appPostAdapter.selectResponses)

const selectLoginState = createSelector(selectStore,state => state.loginState)
export const selectIsLogin = createSelector(selectLoginState,state => state.isLogin)
export const selectLoginResponse = createSelector(selectLoginState,state => state.loginResponse)
export const selectUserId = createSelector(selectLoginResponse,state => state?.userId)
export const selectAccessToken = createSelector(selectLoginResponse,state => state?.accessToken)

const selectPostImages = createSelector(selectStore,state => state.postImages)
export const selectPostImage = (props : {id : number}) => createSelector( selectPostImages, state => state.entities[props.id] )
export const selectPostImageUrl = (props : {id : number}) => createSelector( selectPostImage(props), state => state?.url )
export const selectPostImageLoadStatus = (props : {id : number}) => createSelector( selectPostImage(props), state => state?.loadStatus )

const selectUserImages = createSelector(selectStore,state => state.userImages)
export const selectUserImage = (props : {id : number}) => createSelector(selectUserImages,state => state.entities[props.id])
export const selectUserImageUrl = (props : {id : number}) => createSelector( selectUserImage(props),state => state?.url)
export const selectUserImageLoadStatus = (props : {id : number}) => createSelector( selectUserImage(props),state => state?.loadStatus )
