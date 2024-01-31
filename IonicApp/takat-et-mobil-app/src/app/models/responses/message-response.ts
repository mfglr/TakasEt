import { BaseResponse } from "./base-response";

export enum MessageState {
  Saved = 0,
  Arrived = 1,
  Viewed = 2
}

export interface MessageResponse extends BaseResponse{
  senderId? : number
  receiverId? : number
  groupId? : number
  content : string
  status : number
}
