import { BaseResponse } from "./base-response";

export interface PostResponse extends BaseResponse{
  userName : string;
  userId : string;
  categoryName : string;
  title : string;
  content : string;
  publishDate : Date;
}
