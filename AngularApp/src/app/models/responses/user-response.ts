import { BaseResponse } from "./base-response";

export interface UserResponse extends BaseResponse{
    userName : string;
    email : string;
	name? : string
	lastName? : string;
	countOfFolloweds : number;
	countOfFollowers : number;
    countOfPosts : number;
	profileImage : string;
}
