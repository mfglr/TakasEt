import { CommentResponse } from "src/app/models/responses/comment-response";

export const message = "kulaniciya yanit ver"

export interface RepliedCommentState{
    parentComment : CommentResponse | undefined;
    comment : CommentResponse | undefined;
    userName : String | undefined;
    status : boolean;
}