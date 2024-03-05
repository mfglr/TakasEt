import { BaseResponse } from "src/app/models/responses/base-response";
import { MessageResponse } from "src/app/models/responses/message-response";
import { UserResponse } from "src/app/models/responses/user-response";

export interface ConversationResponse extends BaseResponse{
  receiver? : UserResponse;
  countOfMessagesUnviewed : number;
  dateTimeOfLastMessageReceived : string;
  lastMessage? : MessageResponse
}
