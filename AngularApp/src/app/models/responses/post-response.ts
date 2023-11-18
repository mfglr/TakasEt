import { AppFileResponse } from "./app-file-response";
import { BaseResponse } from "./base-response";

export interface PostResponse extends BaseResponse{
  userName : string;
  userId : number;
  categoryName : string;
  title : string;
  content : string;
  countOfImages : number;
  countOfLikes : number;
  countOfViews : number;
  countOfComments : number;
  postImages : AppFileResponse[];
}
