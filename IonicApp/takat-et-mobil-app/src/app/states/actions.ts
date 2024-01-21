import { createAction, props } from "@ngrx/store"
import { PostResponse } from "../models/responses/post-response";
import { UserResponse } from "../models/responses/user-response";
import { LoginResponse } from "../models/responses/login-response";

// Image Store
export const loadUserImagesSuccessAction = createAction(
  "[App Store] load user images success",
  props<{userImageIds : number[]}>()
)
export const loadUserImagesByPostResponsesSuccessAction = createAction(
  "[App Store] load user images by post responses success",
  props<{payload : PostResponse[]}>()
)
export const loadPostImagesSuccessAction = createAction(
  "[App Store] load post images success",
  props<{postImageIds : number[]}>()
)
export const loadPostImagesByPostResponsesSuccessAction = createAction(
  "[App Store] load post images by post responses success",
  props<{ payload : PostResponse[]}>()
)
export const loadConversationImagesSuccess = createAction(
  "[App Store] load conversation images success",
  props<{conversationImageIds : number[]}>()
)

export const loadUserImageUrlAction = createAction(
  "[App Store] load user image url",
  props<{id : number}>()
)
export const loadUserImageUrlSuccessAction = createAction(
  "[App Store] load user image url success",
  props<{url : string}>()
)
export const loadPostImageUrlAction = createAction(
  "[App Store] load post image url",
  props<{id : number}>()
)
export const loadPostImageUrlSuccessAction = createAction(
  "[App Store] load post image url success",
  props<{url : string}>()
)
export const loadConversationImageUrlAction = createAction(
  "[App Store] load conversation image url",
  props<{id : number}>()
)
export const loadConversationImageUrlSuccessAction = createAction(
  "[App Store] load conversation image url success",
  props<{url : string}>()
)

//profile Store
export const nextPostsAction = createAction("[App Store] next posts")
export const nextPostsSuccessAction = createAction(
  "[App Store] next posts success",
  props<{payload : PostResponse[]}>()
)

export const nextSwappedPostsAction = createAction("[App Store] next swapped posts")
export const nextSwappedPostsSuccessAction = createAction(
  "[App Store] next swapped posts success",
  props<{payload : PostResponse[]}>()
)

export const nextNotSwappedPostsAction = createAction("[App Store] next not swapped posts")
export const nextNotSwappedPostsSuccessAction = createAction(
  "[App Store] next not swapped posts success",
  props<{payload : PostResponse[]}>()
)

export const nextFollowedsAction = createAction("[App Store] next followeds");
export const nextFollowedsSuccessAction = createAction(
  "[App Store] next followeds success",
  props<{payload : UserResponse[]}>()
)

export const nextFollowersAction = createAction("[App Store] next followers")
export const nextFollowersSuccessAction = createAction(
  "[App Store] next followers success",
  props<{payload : UserResponse[]}>()
)

//login Store
export const loginAction = createAction(
  "[App Store] login",
  props<{email : string,password : string}>()
);
export const loginByRefreshTokenAction = createAction(
  "[App Store] login by refresh token",
  props<{refreshToken : string}>()
)
export const loginFromLocalStorageFailedAction = createAction('[App Store] login from local storage failed');
export const loginFromLocalStorageAction = createAction('[App Store] login from local storage')
export const loginSuccessAction = createAction(
  "[App Store] login success",
  props<{payload : LoginResponse}>()
)
