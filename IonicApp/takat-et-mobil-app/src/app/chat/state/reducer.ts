import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { Page } from "src/app/state/app-entity-state/app-entity-state";
import { MessageResponse } from "../models/responses/message-response";
import { ConversationResponse } from "../pages/chat-home/models/responses/conversation-response";
import { createReducer, on } from "@ngrx/store";
import { nextPageMessagesSuccessAction, nextPageSuccessConversationAction } from "./actions";


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
  sortComparer : (x,y) => x.createdDate.localeCompare(y.createdDate)
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
              action.payload[action.payload.length - 1].createdDate :
              state.page.lastValue,
            take : takeValueOfMessage
          }
        }
      },state.conversations)
    })
  )

)

function responseToConversation(response : ConversationResponse) : Conversation{
  return {
    isLast : false,
    page : { isDescending : true, lastValue : undefined, take : 50 },
    conversation : response,
    messages : messageAdapter.getInitialState()
  }
}
