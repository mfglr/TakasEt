import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Chat, conversationAdapter, messageAdapter } from "./reducer";
import { MessageStatus } from "../models/responses/message-response";

export const selectStore = createFeatureSelector<Chat>("ChatStore");
export const selectConversations = createSelector(
  selectStore,
  state => conversationAdapter.getSelectors().selectAll(state.conversations)
)
export const selectConversationResponses = createSelector(
  selectStore,
  state => conversationAdapter.getSelectors().selectAll(state.conversations).map(x => x.conversation)
)
export const selectConversation = (props : {receiverId : string}) => createSelector(
  selectStore,
  state => state.conversations.entities[props.receiverId]
)
export const selectMessageResponses = (props : {receiverId : string}) => createSelector(
  selectConversation(props),
  state => state ? messageAdapter.getSelectors().selectAll(state.messages) : []
)
export const selectCountOfNewMessages = (props : {receiverId : string}) => createSelector(
  selectMessageResponses(props),
  state => state.filter(x => x.status != MessageStatus.Viewed && x.receiverId != props.receiverId).length
)
export const selectIdsOfUnViewedMessages = (props : {receiverId : string}) => createSelector(
  selectMessageResponses(props),
  state => state.filter(x => x.status != MessageStatus.Viewed && x.receiverId != props.receiverId).map(m => m.id)
)
export const selectIdsOfCreatedMessages = createSelector(
  selectConversations,
  state => state.map(x => messageAdapter.getSelectors().selectAll(x.messages).map(x => x.id)).reduce((x,y) => x.concat(y))
)
export const selectLastMessage = (props : {receiverId : string}) => createSelector(
  selectMessageResponses(props),
  state => state[0]
)
