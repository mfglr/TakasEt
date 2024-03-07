import { MessageImageResponse } from "src/app/chat/models/responses/message-image-response";
import { BaseResponse } from "../../../models/responses/base-response";

export enum MessageStatus { NotCreated = -1, Created = 0, Received = 1, Viewed = 2 }

export interface MessageResponse extends BaseResponse{
  senderId : string;
  receiverId : string;
  content : string;
  status : MessageStatus;
  sendDate : Date,
  receivedDate? : Date,
  viewedDate? : Date,
  images? : MessageImageResponse[]
}
