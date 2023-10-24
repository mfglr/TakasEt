import { EntityState } from "@ngrx/entity";
import { CommentResponse } from "../models/responses/comment-response";
import { PostResponse } from "../models/responses/post-response";
import { UserResponse } from "../models/responses/user-response";

export const takeValueOfPosts = 1;
export const takeValueOfComments = 1;
export const takeValueOfUsers = 1;

export const initialPageOfPosts = { skip : 0, take : takeValueOfPosts,firstQueryDate : Date.now() }
export const initialPageOfComments = { skip : 0, take : takeValueOfComments,firstQueryDate : Date.now() }
export const initialPageOfUsers = { skip : 0, take : takeValueOfUsers,firstQueryDate : Date.now() }

export interface Page{
  skip : number;
  take : number;
  firstQueryDate : number;
}

export interface AppEntityState<T> extends EntityState<T>{
  status : boolean;
  page : Page;
}

export interface UserState{
  user : UserResponse;
  posts : PostsState;
  followers : UsersState;
  followeds : UsersState;
}
export interface UsersState extends AppEntityState<UserState>{}

export interface CommentState{
  comment : CommentResponse;
  children : CommentsState;
  likers : UsersState;
}
export interface CommentsState extends AppEntityState<CommentState>{}

export interface PostState{
  post : PostResponse;
  comments : CommentsState;
  likers : UsersState;
  views : UsersState;
  requesters : PostsState;
  requesteds : PostsState;
  followers : UsersState;
}
export interface PostsState extends AppEntityState<PostState>{}

