import { createAction, props } from "@ngrx/store";
import { ConversationResponse } from "../models/responses/conversation-response";
import { MessageResponse } from "../models/responses/message-response";
import { SendMessage } from "../models/request/send-message";
import { UserResponse } from "src/app/models/responses/user-response";
import { BaseAppresponse } from "src/app/models/responses/app-response";
import { MarkMessagesAsReceived } from "../models/request/mark-messages-as-received";
import { MessageState, UserState } from "./reducer";

export const connectionFailedAction = createAction("[Chat Module State] connection failed");
export const connectionSuccessAction = createAction("[Chat Module State] connectin success");

export const loadNewMessagesAction = createAction("[Chat Module State] load new messages")
export const loadNewMessagesSuccessAction = createAction(
  "[Chat Module State] load conversations with new messages success",
  props<{payload : MessageResponse[],receivedDate : Date}>()
)

export const synchronizedSuccessAction = createAction("[Chat Module State] synchronized success")
export const synchronizedFailedAction = createAction("[Chat Module State] synchronized failed")

export const loadConversationUserAction = createAction(
  '[Chat Module State] load conversation user',
  props<{userId : string}>()
)
export const loadConversationUserSuccessAction = createAction(
  "load conversation user success action",
  props<{payload : UserResponse}>()
)

export const nextPageConversationsAction = createAction("[Chat Module State] next page conversation")
export const nextPageConversationsSuccessAction = createAction(
  "[Chat Module State] next page conversations success",
  props<{payload : ConversationResponse[],receivedDate : Date}>()
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

export const nextPageMessagesAction = createAction(
  "[Chat Module State] next page message",
  props<{user : UserState}>()
)
export const nextPageMessagesSuccessAction = createAction(
  "[Chat Module State] next page messages success",
  props<{user : UserState, payload : MessageResponse[]}>()
)

export const sendMessageSuccessAction = createAction(
  "[Chat Module State] send message success",
  props<{request : SendMessage,userState : UserState}>()
)
export const sendMessageFailedAction = createAction(
  "[Chat Module State] send message failed"
)

export const markMessageAsCreatedSuccessAction = createAction(
  "[Chat Module State] mark message as created success",
  props<{message : MessageResponse}>()
)

export const receiveMessageSuccessAction = createAction(
  "[Chat Module State] receive message",
  props<{payload : MessageResponse}>()
)
export const markMessagesAsReceivedAction = createAction(
  "[Chat Module State] mark messages as received",
  props<{request: MarkMessagesAsReceived}>()
)
export const markMessageAsReceivedSuccessAction = createAction(
  "[Chat Module State] mark message as received success",
  props<{payload : MessageResponse}>()
)
export const markMessagesAsReceivedSuccessAction = createAction(
  "[Chat Module State] mark messages as received success",
  props<{payload : MessageResponse[]}>()
)
export const markMessagesAsReceivedFailedAction = createAction(
  "[Chat Module State] mark messages as received failed"
)

export const markMessageSentAsViewedAction = createAction(
  "[Chat Module State] mark message sent as viewed",
  props<{payload : MessageResponse}>()
)
export const markMessageReceivedAsViewedAction = createAction(
  "[Chat Module State] mark message received as viewed",
  props<{payload : MessageResponse}>()
)
export const markMessagesSentAsViewedAction = createAction(
  "[Chat Module State] mark messages sent as viewed",
  props<{payload : MessageResponse[]}>()
)
export const markMessagesReceivedAsViewedAction = createAction(
  "[Chat Module State] mark messages received as viewed",
  props<{payload : MessageState[],viewedDate : Date}>()
)
