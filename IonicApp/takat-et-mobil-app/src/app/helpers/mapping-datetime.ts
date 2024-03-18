import { MessageResponse } from "../chat/models/responses/message-response";

export function mapDateTimesOfMessageResponse(message : MessageResponse) : MessageResponse{
  return {
    ...message,
    updatedDate : message.updatedDate ? new Date(message.updatedDate) : message.updatedDate,
    createdDate : new Date(message.createdDate),
    sendDate : new Date(message.sendDate),
    receivedDate : message.receivedDate ? new Date(message.receivedDate) : message.receivedDate,
    viewedDate : message.viewedDate ? new Date(message.viewedDate) : message.viewedDate
  }
}
