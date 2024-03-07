import { EntityState, Update, createEntityAdapter } from "@ngrx/entity";
import { Page } from "src/app/state/app-entity-state/app-entity-state";
import { MessageResponse, MessageStatus } from "../models/responses/message-response";
import { ConversationResponse } from "../models/responses/conversation-response";
import { createReducer, on } from "@ngrx/store";
import { markMessageAsCreatedSuccessAction, markMessageAsReceivedSuccessAction, markMessageAsViewedSuccessAction, markMessagesAsViewedSuccessAction, nextPageMessagesSuccessAction, nextPageSuccessConversationAction, receiveMessageAction, sendMessageSuccessAction } from "./actions";


export const takeValueOfMessage = 50;
export const takeValueOfConversation = 20;

export interface Conversation{
  isLast : boolean;
  page : Page;
  conversation : ConversationResponse;
  messages : EntityState<MessageResponse>;
}
export const messageAdapter = createEntityAdapter<MessageResponse>({
  selectId : state => state.id,
  sortComparer : (x,y) => x.sendDate < y.sendDate ? 1 : -1
})

export interface Conversations{
  isLast : boolean;
  page : Page;
  conversations : EntityState<Conversation>
}
export const conversationAdapter = createEntityAdapter<Conversation>({
  selectId : state => state.conversation.receiverId,
  sortComparer : (x,y) => x.conversation.dateTimeOfLastMessage.localeCompare(y.conversation.dateTimeOfLastMessage)
})

export interface Chat extends Conversations{

}

const initialState : Chat = {
  conversations : conversationAdapter.getInitialState(),
  isLast : false,
  page : { isDescending : true, lastValue : undefined, take : takeValueOfConversation }
}

export const chatReducer = createReducer(
  initialState,
  on(
    nextPageSuccessConversationAction,
    (state,action) => ({
      conversations : conversationAdapter.addMany(action.payload.map(x => responseToConversation(x)),state.conversations),
      isLast : action.payload.length < takeValueOfConversation,
      page : {
        isDescending : true,
        lastValue :
          action.payload.length > 0 ?
          action.payload[action.payload.length - 1].dateTimeOfLastMessage :
          state.page.lastValue,
        take : takeValueOfConversation
      }
    })
  ),
  on(
    nextPageMessagesSuccessAction,
    (state,action) => ({
      ...state,
      conversations : conversationAdapter.updateOne({
        id : action.receiverId,
        changes : {
          messages : messageAdapter.addMany(
            action.payload,
            state.conversations.entities[action.receiverId]!.messages
          ),
          isLast : action.payload.length < takeValueOfMessage,
          page : {
            isDescending : true,
            lastValue :
              action.payload.length > 0 ?
              action.payload[action.payload.length - 1].sendDate :
              state.page.lastValue,
            take : takeValueOfMessage
          }
        }
      },state.conversations)
    })
  ),
  on(
    sendMessageSuccessAction,
    (state,action) => ({
      ...state,
      conversations : conversationAdapter.updateOne({
        id : action.request.receiverId,
        changes : {
          messages : messageAdapter.addOne({
            id : action.request.id,
            createdDate : new Date(),
            receiverId : action.request.receiverId,
            senderId : action.request.senderId,
            sendDate : action.request.sendDate,
            content : action.request.content,
            status : MessageStatus.NotCreated,
          },state.conversations.entities[action.request.receiverId]!.messages)
        }
      },state.conversations)
    })
  ),
  on(
    markMessageAsCreatedSuccessAction,
    (state,action) => {
      var message = state.conversations.entities[action.receiverId]!.messages.entities[action.messageId]!
      if(message.status == MessageStatus.Created)
        return state;

      var newState = MessageStatus.Created;
      if(message.status == MessageStatus.Received)
        newState = MessageStatus.Received;

      if(message.status == MessageStatus.Viewed)
        newState = MessageStatus.Viewed;

      return ({
        ...state,
        conversations : conversationAdapter.updateOne({
          id : action.receiverId,
          changes : {
            messages : messageAdapter.updateOne(
              { id : action.messageId, changes : { status : newState }},
              state.conversations.entities[action.receiverId]!.messages
            )
          }
        },state.conversations)
      })
    }
  ),
  on(
    receiveMessageAction,
    (state,action) => ({
      ...state,
      conversations : conversationAdapter.updateOne({
        id : action.payload.senderId,
        changes : {
          messages : messageAdapter.addOne(
            action.payload,
            state.conversations.entities[action.payload.senderId]!.messages
          )
        }
      },state.conversations)
    })
  ),
  on(
    markMessageAsReceivedSuccessAction,
    (state,action) => {
      var message = state.conversations.entities[action.receiverId]!.messages.entities[action.messageId]!

      if(message.status == MessageStatus.Received)
        return state;

      var newState = MessageStatus.Received;
      if(message.status == MessageStatus.Viewed)
        newState = MessageStatus.Viewed;

      return ({
        ...state,
        conversations : conversationAdapter.updateOne({
          id : action.receiverId,
          changes : {
            messages : messageAdapter.updateOne({
              id : action.messageId, changes : { status : newState,receivedDate : action.receivedDate }
            },state.conversations.entities[action.receiverId]!.messages)
          }
        },state.conversations)
      })
    }
  ),
  on(
    markMessageAsViewedSuccessAction,
    (state,action) => {
      var message = state.conversations.entities[action.receiverId]!.messages.entities[action.messageId]!
      if(message.status == MessageStatus.Viewed)
        return state;
      return ({
        ...state,
        conversations : conversationAdapter.updateOne({
          id : action.receiverId,
          changes : {
            messages : messageAdapter.updateOne({
              id : action.messageId, changes : { status : MessageStatus.Viewed,viewedDate : action.viewedDate }
            },state.conversations.entities[action.receiverId]!.messages)
          }
        },state.conversations)
      })
    }
  ),
  on(
    markMessagesAsViewedSuccessAction,
    (state,action) => ({
      ...state,
      conversations : conversationAdapter.updateOne({
        id : action.receiverId,
        changes : {
          messages : messageAdapter.updateMany(
            action.ids.map((x) : Update<MessageResponse> => ({id : x, changes : {status : MessageStatus.Viewed}})),
            state.conversations.entities[action.receiverId]!.messages)
        }
      },state.conversations)
    })
  )
)

function responseToConversation(response : ConversationResponse) : Conversation{
  var messages =
    response.newMessages.length > 0 ?
    response.newMessages :
      response.lastMessage ?
      [response.lastMessage] :
      [];

  return {
    isLast : false,
    page : {
      isDescending : true,
      lastValue : messages.length > 0 ? messages[messages.length - 1].sendDate : undefined,
      take : 50
    },
    conversation : response,
    messages : messageAdapter.addMany(messages,messageAdapter.getInitialState())
  }
}
