import { AppFileResponse } from "./app-file-response";

export interface PostImageResponse extends AppFileResponse{
    postId : number;
    index : number
}