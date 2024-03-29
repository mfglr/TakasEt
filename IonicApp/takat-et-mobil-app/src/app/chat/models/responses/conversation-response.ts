import { BaseResponse } from "src/app/models/responses/base-response";
import { MessageResponse } from "src/app/chat/models/responses/message-response";
import { UserResponse } from "src/app/models/responses/user-response";

export interface ConversationResponse extends BaseResponse{
  userId : string;
  messages : MessageResponse[];
}
