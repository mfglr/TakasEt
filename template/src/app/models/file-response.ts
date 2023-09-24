import { BaseResponse } from "./base-response";

export interface FileResponse extends BaseResponse{
    blobName? : string;
    containerName? : string;
}