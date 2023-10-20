import { EntityState } from "@ngrx/entity";
import { CommentResponse } from "../models/responses/comment-response";
import { UserResponse } from "../models/responses/user-response";
import { PostResponse } from "../models/responses/post-response";

export const takeValueOfPosts = 1;
export const takeValueOfComments = 1;
export const takeValueOfUsers = 10;

export const initialPageOfPosts = { skip : 0, take : takeValueOfPosts,firstQueryDate : Date.now() }
export const initialPageOfComments = { skip : 0, take : takeValueOfComments,firstQueryDate : Date.now() }
export const initialPageOfUsers = { skip : 0, take : takeValueOfUsers,firstQueryDate : Date.now() }

export interface Page{
  skip : number;
  take : number;
  firstQueryDate : number;
}

export interface AppState<T>{
  entities : T[];
  selectedId : string | undefined,
  status : boolean;
  page : Page;
}

export interface AppEntityState<T> extends EntityState<T>{
  selectedId : string | undefined,
  status : boolean;
  page : Page;
}
export interface CommentState{
  comment : CommentResponse;
  childrend : CommentsState;
}
export interface CommentsState extends AppEntityState<CommentState>{}
export interface PostState{
  post : PostResponse;
  comments : CommentsState;
  usersLiked : UsersState;
  usersViewed : UsersState;
}
export interface PostsState extends AppEntityState<PostState>{}
export interface UserState{
  user : UserResponse;
  posts : PostsState;
  followeds : UsersState;
  followers : UsersState;
}
export interface UsersState extends AppEntityState<UserState>{}

