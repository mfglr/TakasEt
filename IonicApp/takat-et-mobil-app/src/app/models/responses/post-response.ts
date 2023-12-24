import { BaseResponse } from "./base-response";
import { PostImageResponse } from "./post-image-response";
import { UserImageResponse } from "./profile-image-response";

export interface PostResponse extends BaseResponse{
  userName : string;
  userId : number;
  categoryId : number,
  categoryName : string;
  title : string;
  content : string;
  countOfImages : number;
  countOfLikes : number;
  countOfComments : number;
  likeStatus : boolean;
  postImages : PostImageResponse[];
  userImage : UserImageResponse;
  tags : string[];
}
