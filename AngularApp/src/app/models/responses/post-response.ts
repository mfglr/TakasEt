import { BaseResponse } from "./base-response";

export interface PostResponse extends BaseResponse{
  userName : string;
  userId : number;
  categoryName : string;
  title : string;
  content : string;
  publishDate : Date;
  countOfImages : number;
  countOfLikes : number;
  countOfViews : number;
  countOfComments : number;
  firstImage : string;
}
