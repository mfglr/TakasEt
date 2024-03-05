import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ChatHomePageState, conversationStateAdapter } from "./reducer";

const selectStore = createFeatureSelector<ChatHomePageState>("ChatHomePageStore");
export const selectConversations = createSelector(selectStore,state => state.conversations);
export const selectConversationResponses = createSelector(
  selectConversations,
  state => conversationStateAdapter.selectResponses(state)
)
