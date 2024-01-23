import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { LoginResponse } from "../models/responses/login-response";
import { PostResponse } from "../models/responses/post-response";
import { UserResponse } from "../models/responses/user-response";
import { AppEntityState } from "./app-entity-state/app-entity-state";
import { createReducer, on } from "@ngrx/store";
import { loadConversationImagesSuccess, loadPostImageUrlSuccessAction, loadPostImagesByPostResponsesSuccessAction, loadPostImagesSuccessAction, loadUserImageSuccessAction, loadUserImageUrlSuccessAction, loadUserImagesByPostResponsesSuccessAction, loadUserImagesSuccessAction, loginSuccessAction } from "./actions";
import { appPostAdapter, appUserAdapter } from "./app-entity-state/app-entity-adapter";

interface ImageState{
  id : number;
  loadStatus : boolean;
  url : string | undefined;
}

interface UserImageState extends ImageState{}
interface PostImageState extends ImageState{}
interface ConversationImageState extends ImageState{}

interface LoginState{
  loginResponse : LoginResponse | undefined;
  isLogin : boolean;
}

interface ProfileState{
  posts : AppEntityState<PostResponse>;
  swappedPosts : AppEntityState<PostResponse>;
  notSwappedPosts : AppEntityState<PostResponse>;
  followers : AppEntityState<UserResponse>;
  followeds : AppEntityState<UserResponse>;
}

export interface AppState{
  userImages : EntityState<UserImageState>,
  postImages : EntityState<PostImageState>,
  conversationImages : EntityState<ConversationImageState>,
  profileState : ProfileState,
  loginState : LoginState
}

const userImagesAdapter = createEntityAdapter<UserImageState>({selectId : state => state.id})
const postImagesAdapter = createEntityAdapter<PostImageState>({selectId : state => state.id})
const conversationImagesAdapter = createEntityAdapter<ConversationImageState>({selectId : state => state.id})



const initialState : AppState = {
  postImages : postImagesAdapter.getInitialState(),
  userImages : userImagesAdapter.getInitialState(),
  conversationImages : conversationImagesAdapter.getInitialState(),
  loginState : { isLogin : false, loginResponse : undefined },
  profileState : {
    followeds : appUserAdapter.init(),
    followers : appUserAdapter.init(),
    posts : appPostAdapter.init(),
    swappedPosts : appPostAdapter.init(),
    notSwappedPosts :appPostAdapter.init(),
  }
}

export const appReducer = createReducer(
  initialState,
  on(
    loginSuccessAction,
    (state,action) => {
      localStorage.setItem('login_response',JSON.stringify(action.payload));
      return {
        ...state,
        loginState : { loginResponse : action.payload,isLogin : true }
      }
    }
  ),
  on(
    loadPostImagesSuccessAction,
    (state,action) => ({
      ...state,
      postImages : postImagesAdapter.addMany(
        action.postImageIds.map( (id) : PostImageState => ({ id : id, loadStatus : false, url : undefined }) ),
        state.postImages
      )
    })
  ),
  on(
    loadPostImagesByPostResponsesSuccessAction,
    (state, action) => ({
      ...state,
      postImages : action.payload.length > 0 ?
        postImagesAdapter.addMany(
          action.payload
            .map(
              x => x.postImages.map(
                (x) : PostImageState => ({ id : x.id, loadStatus : false, url : undefined })
              )
            )
            .reduce((prev,cur) => prev.concat(cur)),
          state.postImages
        ) :
        state.postImages
    })
  ),
  on(
    loadUserImageSuccessAction,
    (state,action) => ({
      ...state,
      userImages : action.userImageId ?
        userImagesAdapter.addOne({
          id : action.userImageId,
          loadStatus : false,
          url : undefined
        },state.userImages) :
        state.userImages
    })
  ),
  on(
    loadUserImagesSuccessAction,
    (state,action) => ({
      ...state,
      userImages : userImagesAdapter.addMany(
        action.userImageIds.map( (id) : UserImageState => ({ id : id, loadStatus : false, url : undefined }) ),
        state.userImages
      )
    })
  ),
  on(
    loadUserImagesByPostResponsesSuccessAction,
    (state,action) => ({
      ...state,
      userImages : userImagesAdapter.addMany(
        action.payload.filter(x => x.userImage != undefined).map( (x) : UserImageState => ({id : x.userImage!.id,loadStatus : false,url : undefined})),
        state.userImages
      )
    })
  ),
  on(
    loadConversationImagesSuccess,
    (state,action) => ({
      ...state,
      conversationImages : conversationImagesAdapter.addMany(
        action.conversationImageIds.map( (id) : ConversationImageState => ({id : id,loadStatus : false,url : undefined}) ),
        state.conversationImages
      )
    })
  ),
  on(
    loadPostImageUrlSuccessAction,
    (state,action) => ({
      ...state,
      postImages : postImagesAdapter.updateOne({
        id : action.id,
          changes : { loadStatus : true, url : action.url }
      },state.postImages)
    })
  ),
  on(
    loadUserImageUrlSuccessAction,
    (state,action) =>({
      ...state,
      userImages : userImagesAdapter.updateOne({
        id : action.id,
        changes : { loadStatus : true,url : action.url }
      },state.userImages)
    })
  )
)
