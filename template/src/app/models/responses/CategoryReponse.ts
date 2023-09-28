import { BaseResponse } from "./base-response";

export interface CategoryResponse extends BaseResponse{
  name : string;
  description : string;
}
