import { createAction, props } from "@ngrx/store";
import { ConversationResponse } from "../pages/chat-home/models/responses/conversation-response";
import { MessageResponse } from "../models/responses/message-response";
import { SendMessage } from "../models/request/send-message";

export const nextPageConversationsAction = createAction("[Chat Module State] next page conversation")
export const nextPageSuccessConversationAction = createAction(
  "[Chat Module State] next page conversations success",
  props<{payload : ConversationResponse[]}>()
)
export const nextPageMessagesAction = createAction(
  "[Chat Module State] next page message",
  props<{receiverId : string}>()
)
export const nextPageMessagesSuccessAction = createAction(
  "[Chat Module State] next page messages success",
  props<{receiverId : string,payload : MessageResponse[]}>()
)

export const sendMessage = createAction(
  "[Chat Module State] send message",
  props<{request : SendMessage}>()
)
