import { createAction, props } from "@ngrx/store";
import { ConversationResponse } from "../models/responses/conversation-response";
import { MessageResponse } from "../models/responses/message-response";
import { SendMessage } from "../models/request/send-message";
import { MarkAllNewMessagesAsReceived } from "../models/request/mark-all-new-messages-as-received";
import { UserResponse } from "src/app/models/responses/user-response";
import { BaseAppresponse } from "src/app/models/responses/app-response";

export const connectionFailedAction = createAction("[Chat Module State] connection failed");
export const connectionSuccessAction = createAction("[Chat Module State] connectin success");

export const loadNewMessagesAction = createAction("[Chat Module State] load new messages")
export const loadNewMessagesSuccessAction = createAction(
  "[Chat Module State] load conversations with new messages success",
  props<{payload : ConversationResponse[],receivedDate : Date}>()
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
export const nextPageConversationsFailedAction = createAction(
  "[Chat Module State] next page conversations failed",
  props<{payload : BaseAppresponse}>()
)

export const nextPageUsersAction = createAction("[Chat Module State] next page users")
export const nextPageUsersSuccessAction = createAction(
"[Chat Module State] next page users success",
  props<{payload : UserResponse[]}>()
)
export const nextPageUsersFailedAction = createAction(
  "[Chat Module State] next page users failed",
  props<{payload : BaseAppresponse}>()
)

export const nextPageMessagesAction = createAction("[Chat Module State] next page message",props<{userId : string}>())
export const nextPageMessagesSuccessAction = createAction(
  "[Chat Module State] next page messages success",
  props<{userId : string, payload : MessageResponse[]}>()
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

