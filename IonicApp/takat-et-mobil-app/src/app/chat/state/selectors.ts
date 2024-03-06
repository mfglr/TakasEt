import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Chat, conversationAdapter, messageAdapter } from "./reducer";

export const selectStore = createFeatureSelector<Chat>("ChatStore");
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
