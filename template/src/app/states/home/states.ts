import { CommentResponse } from "src/app/models/responses/comment-response";
import { AppEntityState, AppState } from "../app-state";
import { UserResponse } from "src/app/models/responses/user-response";
import { PostResponse } from "src/app/models/responses/post-response";

export interface CommentState{comment : CommentResponse;children : CommentsState;}
export interface CommentsState extends AppState<CommentState>{}
export interface UserState{user : UserResponse;}
export interface UsersState extends AppState<UserState>{}
export interface PostState{post : PostResponse;comments : CommentsState;usersLiked : UsersState;usersViewed : UsersState;}
export interface HomeState extends AppEntityState<PostState>{}
