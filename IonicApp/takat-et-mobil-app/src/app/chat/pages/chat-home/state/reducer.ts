import { createReducer, on } from "@ngrx/store";
import { AppEntityAdapter } from "src/app/state/app-entity-state/app-entity-adapter";
import { AppEntityState, Pagination } from "src/app/state/app-entity-state/app-entity-state";
import { nextPageConversationsSuccessAction } from "./actions";
import { ConversationResponse } from "../models/responses/conversation-response";


export interface ConversationState extends Pagination<ConversationResponse>{}
export const conversationStateAdapter = new AppEntityAdapter<ConversationResponse,ConversationState>(20);

export interface ChatHomePageState{
  conversations : AppEntityState<ConversationResponse,ConversationState>
}

const initialState : ChatHomePageState = {
  conversations : conversationStateAdapter.init()
}

export const chatHomePageReducer = createReducer(
  initialState,
  on(
    nextPageConversationsSuccessAction,
    (state,action) => ({
      ...state,
      conversations : conversationStateAdapter.nextPage(
        action.payload.map((x) : ConversationState => ({ entity : x, paginationProperty : x.dateTimeOfLastMessageReceived })),
        state.conversations
      )
    })
  )

)
