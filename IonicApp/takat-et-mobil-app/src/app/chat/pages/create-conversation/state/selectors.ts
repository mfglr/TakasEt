import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CreateConversationPageState } from "./reducer";
import { appUserAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<CreateConversationPageState>("CreateConversationPageStore");
export const selectUsers = createSelector(selectStore,state => state.users);
export const selectUserResponses = createSelector(selectUsers, state => appUserAdapter.selectResponses(state))
