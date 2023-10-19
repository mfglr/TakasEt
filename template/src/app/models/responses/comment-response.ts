import { BaseResponse } from "./base-response";

export interface CommentResponse extends BaseResponse{
  postId? : string;
  parentId? : string;
	userId : string;
	userName : string;
  content : string;
  countOfChildren : number;

  children : CommentResponse[];
}
