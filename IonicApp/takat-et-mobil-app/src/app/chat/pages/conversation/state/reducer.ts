import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { createReducer, on } from "@ngrx/store";
import { MessageResponse, MessageState } from "src/app/models/responses/message-response";
import { AppEntityState, Pagination } from "src/app/state/app-entity-state/app-entity-state";
import { initPageAction, markAsReceivedAction, markAsSavedAction, nextPageMessagesSuccessAction, receiveMessageAction, sendMessageAction } from "./actions";
import { AppEntityAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

export interface MessagePageState extends Pagination<MessageResponse>{}
export const messageStateAdapter = new AppEntityAdapter<MessageResponse,MessagePageState>(
  50,
  (x,y) => x.paginationProperty.localeCompare(y.paginationProperty)
);

export interface ConversationPageState{
  receiverId : string;
  messages : AppEntityState<MessageResponse,MessagePageState>;
}

export interface State extends EntityState<ConversationPageState>{}

export const adapter = createEntityAdapter<ConversationPageState>({
  selectId : state => state.receiverId
})


export const conversationPageReducer = createReducer(
  adapter.getInitialState(),
  on(
    initPageAction,
    (state,action) => adapter.addOne({
      receiverId : action.userId,
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

      var date = new Date().toString();
      var messagePageState : MessagePageState = {
        entity : {
          id : action.request.id,
          createdDate : date,
          conversationId : "",
          senderId : action.request.senderId,
          content : action.request.content,
          receiverId : action.request.receiverId,
          status : MessageState.NotSaved,
        },
        paginationProperty :date
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
      return adapter.addOne(
        {
          messages : messageStateAdapter.addOne(messagePageState,messageStateAdapter.init()),
          receiverId :action.request.receiverId
        },state
      )
    }
  ),
  on(
    markAsSavedAction,
    (state,action) => {
      return adapter.updateOne({
        id : action.payload.receiverId,
        changes : {
          messages : messageStateAdapter.updateOne(
            {
              id : action.payload.id,
              changes : {
                paginationProperty : action.payload.createdDate,
                entity : action.payload
              }
            },
            state.entities[action.payload.receiverId]!.messages
          )
        }
      },state)
    }
  ),
  on(
    receiveMessageAction,
    (state,action) => adapter.updateOne({
      id : action.receiverId,
      changes : {
        messages : messageStateAdapter.addOne({
          entity : action.payload,
          paginationProperty : action.payload.createdDate
        },state.entities[action.receiverId]!.messages)
      }
    },state)
  ),
  on(
    markAsReceivedAction,
    (state,action) => {
      return adapter.updateOne({
        id : action.payload.receiverId,
        changes : {
          messages : messageStateAdapter.updateOne(
            {
              id : action.payload.id,
              changes : {
                paginationProperty : action.payload.createdDate,
                entity : action.payload
              }
            },
            state.entities[action.payload.receiverId]!.messages
          )
        }
      },state)
    }
  )
)
