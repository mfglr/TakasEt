import { BaseResponse } from "./base-response";
import { UserImageResponse } from "./profile-image-response";

export interface UserResponse extends BaseResponse{
  userName : string;
  email : string;
	name? : string
	lastName? : string;
	countOfFolloweds : number;
	countOfFollowers : number;
  countOfPosts : number;
  isFollower : boolean;
  isFollowed : boolean;
	userImage : UserImageResponse;
}
