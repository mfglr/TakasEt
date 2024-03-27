import { createAction, props } from "@ngrx/store";
import { ConversationResponse } from "../models/responses/conversation-response";
import { MessageResponse } from "../models/responses/message-response";
import { UserResponse } from "src/app/models/responses/user-response";
import { BaseAppresponse } from "src/app/models/responses/app-response";
import { UserState } from "./reducer";
import { HubConnectionState } from "@microsoft/signalr";

export const createMessageAction = createAction(
  "[Chat Module State] create message",
  props<{
    paths : {webPath : string,format : string}[],
    message : {id : string, receiverId : string, content? : string, sendDate : number},
    senderId : string,
    userState : UserState
  }>()
)
export const createMessageSuccessAction = createAction(
  "[Chat Module State] create message success",
  props<{payload : MessageResponse,userState : UserState}>()
)
export const createMessageFailedAction = createAction(
  "[Chat Module State] create message failed",
  props<{id : string}>()
)

export const receiveMessageAction = createAction(
  "[Chat Module State] receive message",
  props<{payload : MessageResponse,receivedDate : Date}>()
)
export const viewMessageAction = createAction(
  "[Chat Module State] viewe message",
  props<{id : string,viewedDate : Date}>()
)

export const markMessageSentAsReceivedAction = createAction(
  "[Chat Module State] the message sent has been received by receiver",
  props<{messageId : string,receivedDate : Date}>()
)
export const markMessageSentAsViewedAction = createAction(
  "[Chat Module State] the message sent has been viewed by receiver",
  props<{messageId : string,viewedDate : Date}>()
)

export const changeHubConnectionStateAction = createAction(
  "[Chat Module State] change hub connection state",
  props<{payload : HubConnectionState}>()
)

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

export const nextPageMessagesAction = createAction(
  "[Chat Module State] next page message",
  props<{user : UserState}>()
)
export const nextPageMessagesSuccessAction = createAction(
  "[Chat Module State] next page messages success",
  props<{user : UserState, payload : MessageResponse[]}>()
)

export const loadMessageImageAction = createAction(
  "[Chat Module State] load message image",
  props<{id : string,imageIndex : number,blobName : string,extention : string}>()
)
export const loadMessageImageSuccessAction = createAction(
  "[Chat Module State] load message image success",
  props<{id : string,imageIndex : number,url : string}>()
)
