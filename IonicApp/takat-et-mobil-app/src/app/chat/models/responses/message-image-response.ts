import { BaseResponse } from "src/app/models/responses/base-response";

export interface MessageImageResponse extends BaseResponse{
  blobName : string;
  extention : string;
  height : number;
  width : number;
  aspectRatio : number;
}
