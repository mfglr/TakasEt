import { BaseResponse } from "./base-response";

export interface AppFileResponse extends BaseResponse{
    blobName : string;
    containerName : string;
    extention : string;
}