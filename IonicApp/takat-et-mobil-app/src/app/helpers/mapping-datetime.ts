import { MessageResponse } from "../chat/models/responses/message-response";

export function mapDateTimesOfMessageResponse(message : MessageResponse) : MessageResponse{
  return {
    ...message,
    updateDate : message.updateDate ? new Date(message.updateDate) : message.updateDate,
    createdDate : new Date(message.createdDate),
    sendDate : new Date(message.sendDate),
    receivedDate : message.receivedDate ? new Date(message.receivedDate) : message.receivedDate,
    viewedDate : message.viewedDate ? new Date(message.viewedDate) : message.viewedDate
  }
}
