import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CreateMessagePageState } from "./reducer";
import { appUserAdapter } from "src/app/state/app-entity-state/app-entity-adapter";

const selectStore = createFeatureSelector<CreateMessagePageState>("CreateMessagePageStore");
export const selectUsers = createSelector(selectStore,state => state.users)
export const selectUserResponses = createSelector(selectUsers,appUserAdapter.selectResponses)
