import { BaseResponse } from "./base-response";
import { CommentResponse } from "./comment-response";
import { UserResponse } from "./user-response";

export interface PostResponse extends BaseResponse{
  userName : string;
  userId : string;
  categoryName : string;
  title : string;
  content : string;
  publishDate : Date;
  countOfLikes : number;
  countOfViews : number;
  countOfComments : number;
  images : string[];
}
