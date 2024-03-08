import { createAction, props } from "@ngrx/store";
import { ConversationResponse } from "../models/responses/conversation-response";
import { MessageResponse } from "../models/responses/message-response";
import { SendMessage } from "../models/request/send-message";
import { MarkAllNewMessagesAsReceived } from "../models/request/mark-all-new-messages-as-received";

export const connectionFailedAction = createAction("[Chat Module State] connection failed");
export const connectionSuccessAction = createAction("[Chat Module State] connectin success");

export const loadConversationsWithNewMessagesAction = createAction(
  "[Chat Module State] load conversations with new messages",
  props<{timeStamp : Date}>()
)
export const loadConversationsWithNewMessagesSuccessAction = createAction(
  "[Chat Module State] load conversations with new messages success",
  props<{payload : ConversationResponse[]}>()
)

export const markAllNewMessagesAsReceivedAction = createAction(
  "[Chat Module State] mark all messages as received",
  props<{request: MarkAllNewMessagesAsReceived}>()
)
export const markAllNewMessagesAsReceivedSuccessAction = createAction(
  "[Chat Module State] mark all new messages as received success"
)
export const markAllNewMessagesAsReceivedFailedAction = createAction(
  "[Chat Module State] mark all new messages as received failed"
)

export const nextPageConversationsAction = createAction("[Chat Module State] next page conversation")
export const nextPageConversationsSuccessAction = createAction(
  "[Chat Module State] next page conversations success",
  props<{payload : ConversationResponse[]}>()
)

export const nextPageMessagesAction = createAction("[Chat Module State] next page message",props<{receiverId : string}>())
export const loadMessagesSuccessAction = createAction(
  "[Chat Module State] load new messages success",
  props<{receiverId : string, payload : MessageResponse[]}>()
)

export const sendMessageSuccessAction = createAction(
  "[Chat Module State] send message success",
  props<{request : SendMessage}>()
)
export const sendMessageFailedAction = createAction(
  "[Chat Module State] send message failed"
)

export const markMessageAsCreatedAction = createAction(
  "[Chat Module State] mark message as created",
  props<{messageId : string,receiverId : string}>()
)
export const markMessageAsCreatedSuccessAction = createAction(
  "[Chat Module State] mark message as created success",
  props<{messageId : string,receiverId : string}>()
)

export const receiveMessageAction = createAction(
  "[Chat Module State] receive message",
  props<{payload : MessageResponse}>()
)

export const markMessageAsReceivedAction = createAction(
  "[Chat Module State] mark message as received",
  props<{messageId : string, receiverId : string, receivedDate : Date}>()
)
export const markMessageAsReceivedSuccessAction = createAction(
  "[Chat Module State] mark message as received success",
  props<{messageId : string, receiverId : string, receivedDate : Date}>()
)

export const markMessageAsViewedAction = createAction(
  "[Chat Module State] mark message as viewed",
  props<{messageId : string,receiverId : string, viewedDate : Date}>()
)
export const markMessageAsViewedSuccessAction = createAction(
  "[Chat Module State] mark message as viewed success",
  props<{messageId : string,receiverId : string, viewedDate : Date}>()
)


export const markNewMessagesAsReceivedAction = createAction(
  "[Chat Module State] mark new messages as received",
  props<{receiverId : string,receivedDate : Date}>()
)
export const markMessagesAsReceivedAction = createAction(
  "[Chat Module State] mark messages as received action",
  props<{receiverId : string,ids : string[], receivedDate : Date}>()
)
export const markMessagesAsReceivedSuccessAction = createAction(
  "[Chat Module State] mark messages as received success",
  props<{receiverId : string,ids : string[], receivedDate : Date}>()
)

export const markNewMessagesAsViewedAction = createAction(
  "[Chat Module State] mark new messages as viewed",
  props<{receiverId : string, viewedDate : Date}>()
)
export const markMessagesAsViewedAction = createAction(
  "[Chat Module State] mark messages as viewed",
  props<{receiverId : string,ids : string[], viewedDate : Date}>()
)
export const markMessagesAsViewedSuccessAction = createAction(
  "[Chat Module State] mark messages as viewed success",
  props<{receiverId : string,ids : string[], viewedDate : Date}>()
)

