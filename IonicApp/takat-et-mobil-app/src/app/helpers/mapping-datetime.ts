import { ConversationResponse } from "../chat/models/responses/conversation-response";
import { MessageResponse } from "../chat/models/responses/message-response";

export function mapDateTimesOfMessageResponse(message : MessageResponse) : MessageResponse{
  return {
    ...message,
    updatedDate : message.updatedDate ? new Date(message.updatedDate) : message.updatedDate,
    createdDate : new Date(message.createdDate),
    sendDate : new Date(message.sendDate),
    receivedDate : message.receivedDate ? new Date(message.receivedDate) : message.receivedDate,
    viewedDate : message.viewedDate ? new Date(message.viewedDate) : message.viewedDate,
    images : message.images?.map(image => ({
      ...image,
      createdDate : new Date(image.createdDate),
      updatedDate : image.updatedDate ? new Date(image.updatedDate) : image.updatedDate
    }))
  }
}
export function mapDateTimesOfMessageResponses(messages : MessageResponse[]) : MessageResponse[]{
  return messages.map(x => mapDateTimesOfMessageResponse(x));
}
export function mapDateTimeOfConversationResponse(conversation : ConversationResponse) : ConversationResponse{
  return {
    ...conversation,
    createdDate : new Date(conversation.createdDate),
    updatedDate : conversation.updatedDate ? new Date(conversation.updatedDate) : conversation.updatedDate,
    messages : mapDateTimesOfMessageResponses(conversation.messages)
  }
}
export function mapDateTimeOfConversationResponses(conversations : ConversationResponse[]) : ConversationResponse[]{
  return conversations.map(conversation => mapDateTimeOfConversationResponse(conversation));
}
