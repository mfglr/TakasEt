import { MessageImageResponse } from "src/app/chat/models/responses/message-image-response";
import { BaseResponse } from "./base-response";

export enum MessageState {
  NotSaved = -1,
  Saved = 0,
  Received = 1,
  Viewed = 2
}

export interface MessageResponse extends BaseResponse{
  senderId : string;
  receiverId : string;
  conversationId : string;
  content : string;
  status : MessageState;
  images? : MessageImageResponse[]
}
