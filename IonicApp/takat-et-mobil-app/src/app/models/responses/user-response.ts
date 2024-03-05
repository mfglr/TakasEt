import { BaseResponse } from "./base-response";
import { UserImageResponse } from "./user-image-response";

export interface UserResponse extends BaseResponse{
  userName : string;
  email : string;
	name? : string
	lastName? : string;
  fullName? : string;
	countOfFollowings : number;
	countOfFollowers : number;
  countOfPosts : number;
  isFollower : boolean;
  isFollowing : boolean;
	images : UserImageResponse[];
}
