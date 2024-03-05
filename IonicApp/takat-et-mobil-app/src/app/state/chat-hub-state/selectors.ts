import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ChatHubState } from "./reducer";

const selectStore = createFeatureSelector<ChatHubState>("ChatHubStore");
export const selectIsConnected = createSelector(selectStore,state => state.isConnected);
