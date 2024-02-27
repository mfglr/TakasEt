import { BaseResponse } from "./base-response";

export interface UserImageResponse extends BaseResponse{
  extention : string;
  containerName : string;
  blobName : string;
  height : number;
  width : number;
  aspectRatio : number;
}
