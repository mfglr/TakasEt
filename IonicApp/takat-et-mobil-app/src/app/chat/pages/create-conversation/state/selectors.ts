import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CreateConversationPageState } from "./reducer";

const selectStore = createFeatureSelector<CreateConversationPageState>("CreateConversationPageStore");
export const selectUsers = createSelector(selectStore,state => state.users);
