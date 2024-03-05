import { createFeatureSelector, createSelector } from "@ngrx/store";
import { State, messageStateAdapter } from "./reducer";

const selectStore = createFeatureSelector<State>("ConversationPageStore")
export const selectMessages = (props : {userId : string}) => createSelector(
  selectStore,
  state => state.entities[props.userId]?.messages
)
export const selectMessageResponses = (props : {userId : string}) => createSelector(
  selectMessages(props),
  state => state ? messageStateAdapter.selectResponses(state) : []
)
