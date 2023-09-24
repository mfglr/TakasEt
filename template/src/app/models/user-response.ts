import { BaseResponse } from "./base-response";

export interface UserResponse extends BaseResponse{
    userName? : string;
    email? : string;
}