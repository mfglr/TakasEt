import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CreateConversationPageState, userStateAdapter } from "./reducer";

const selectStore = createFeatureSelector<CreateConversationPageState>("CreateConversationPageStore");
export const selectUsers = createSelector(selectStore,state => state.users);
export const selectUserResponses = createSelector(selectUsers, state => userStateAdapter.selectResponses(state))