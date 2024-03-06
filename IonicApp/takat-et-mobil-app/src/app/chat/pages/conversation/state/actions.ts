import { createAction, props } from "@ngrx/store";
import { SendMessage } from "src/app/chat/models/request/send-message";
import { MessageResponse } from "src/app/chat/models/responses/message-response";


export const noAction = createAction("[Conversation Page Store] no action");
export const initPageAction = createAction(
  "[Conversation Page Store] init page action",
  props<({userId : string})>()
)

export const nextPageMessagesAction = createAction(
  "[Conversation Page Store] next page message",
  props<{userId : string}>()
)
export const nextPageMessagesSuccessAction = createAction(
  "[Conversation Page Store] next page messages success",
  props<{userId : string,payload : MessageResponse[]}>()
)

export const sendMessageAction = createAction(
  "[Conversation Page Store] send message",
  props<{request : SendMessage}>()
)
export const markAsSavedAction = createAction(
  "[Conversation Page Store] mark as saved",
  props<{userId : string,messageId : string}>()
)

export const receiveMessageAction = createAction(
  "[Conversatin Page Store] receive message",
  props<{payload : MessageResponse}>()
)
export const markAsReceivedAction = createAction(
  "[Conversation Page Store] mark as received",
  props<{messageId : string, receiverId : string}>()
)
export const markAsViewedAction = createAction(
  "[Conversation Page Store] mark as Viewed",
  props<{messageId : string,receiverId : string}>()
)
export const markMessagesAsViewedAction = createAction(
  "[Conversation Page Store] mark messages as viewed",
  props<{receiverId : string,ids : string[]}>()
)
