import { EntityState, Update, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { MessageResponse, MessageStatus } from "src/app/chat/models/responses/message-response";
import { AppEntityState, Pagination } from "src/app/state/app-entity-state/app-entity-state";
import { initPageAction, markAsReceivedAction, markAsSavedAction, markAsViewedAction, markMessagesAsViewedAction, nextPageMessagesSuccessAction, receiveMessageAction, sendMessageAction } from "./actions";
import { AppEntityAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

export interface MessageState extends Pagination<MessageResponse>{}
export const messageStateAdapter = new AppEntityAdapter<MessageResponse,MessageState>(
  50,
  (x,y) => x.paginationProperty.localeCompare(y.paginationProperty)
);

export interface ConversationPageState{
  userId : string;
  messages : AppEntityState<MessageResponse,MessageState>;
}

export interface State extends EntityState<ConversationPageState>{}

export const adapter = createEntityAdapter<ConversationPageState>({
  selectId : state => state.userId
})


export const conversationPageReducer = createReducer(
  adapter.getInitialState(),
  on(
    initPageAction,
    (state,action) => adapter.addOne({
      userId : action.userId,
      messages : messageStateAdapter.init()
    },state)
  ),
  on(
    nextPageMessagesSuccessAction,
    (state,action) => adapter.updateOne({
      id : action.userId,
      changes : {
        messages : messageStateAdapter.nextPage(
          action.payload.map(x => ({
            paginationProperty : x.createdDate,
            entity : x,
          })),
          state.entities[action.userId]!.messages
        )
      }
    },state)
  ),
  on(
    sendMessageAction,
    (state,action) => {

      var messagePageState : MessageState = {
        entity : {
          id : action.request.id,
          createdDate : action.request.sendDate,
          senderId : action.request.senderId,
          receiverId : action.request.receiverId,
          content : action.request.content,
          status : MessageStatus.NotSaved,
        },
        paginationProperty :action.request.sendDate
      }

      if(state.entities[action.request.receiverId]){
        return adapter.updateOne({
          id : action.request.receiverId,
          changes : {
            messages : messageStateAdapter.addOne(
              messagePageState,
              state.entities[action.request.receiverId]!.messages
            )
          }
        },state)
      }
      return adapter.addOne({
        messages : messageStateAdapter.addOne(messagePageState,messageStateAdapter.init()),
        userId :action.request.receiverId
      },state)
    }
  ),
  on(
    markAsSavedAction,
    (state,action) => {

      var message = state.entities[action.userId]!.messages.entities.entities[action.messageId]!.entity;
      if(
          message.status == MessageStatus.Saved ||
          message.status == MessageStatus.Received ||
          message.status == MessageStatus.Viewed
        ) return state;

      return adapter.updateOne({
        id : action.userId,
        changes : {
          messages : messageStateAdapter.updateOne(
            {id : action.messageId, changes : { entity : {...message, status : MessageStatus.Saved}}},
            state.entities[action.userId]!.messages
          )
        }
      },state)

    }
  ),
  on(
    receiveMessageAction,
    (state,action) => adapter.updateOne({
      id : action.payload.senderId,
      changes : {
        messages : messageStateAdapter.addOne({
          entity : action.payload,
          paginationProperty : action.payload.createdDate
        },state.entities[action.payload.senderId]!.messages)
      }
    },state)
  ),
  on(
    markAsReceivedAction,
    (state,action) => {
      var message = state.entities[action.receiverId]!.messages.entities.entities[action.messageId]!.entity;
      if(
        message.status == MessageStatus.Received ||
        message.status == MessageStatus.Viewed
      ) return state;

      return adapter.updateOne({
        id : action.receiverId,
        changes : {
          messages : messageStateAdapter.updateOne(
            {id : action.messageId, changes : { entity : {...message, status : MessageStatus.Received}}},
            state.entities[action.receiverId]!.messages
          )
        }
      },state)

    }
  ),
  on(
    markAsViewedAction,
    (state,action) => {

      var message = state.entities[action.receiverId]!.messages.entities.entities[action.messageId]!.entity;
      if(message.status == MessageStatus.Viewed)
        return state;

      return adapter.updateOne({
        id : action.receiverId,
        changes : {
          messages : messageStateAdapter.updateOne(
            {id : action.messageId, changes : { entity : {...message, status : MessageStatus.Viewed}}},
            state.entities[action.receiverId]!.messages
          )
        }
      },state)
    }
  ),
  on(
    markMessagesAsViewedAction,
    (state,action) => {
      return adapter.updateOne({
        id : action.receiverId,
        changes : {
          messages : messageStateAdapter.updateMany(
            action.ids.map(
              (x) : Update<MessageState> => {
                var message = state.entities[action.receiverId]!.messages.entities.entities[x]!.entity;
                return { id : x, changes : { entity : { ...message, status : MessageStatus.Viewed }}}
              }
            ),
            state.entities[action.receiverId]!.messages
          )
        }
      },state)
    }
  )
)
