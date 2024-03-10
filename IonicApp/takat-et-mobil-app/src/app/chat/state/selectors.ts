import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ChatState, conversationAdapter, messageAdapter, userAdapter } from "./reducer";
import { MessageStatus } from "../models/responses/message-response";

export const selectStore = createFeatureSelector<ChatState>("ChatStore");
export const selectIsConnected = createSelector(selectStore,state => state.isConnected);

//*****************************************************************************************************
export const selectConversationEntityState = createSelector(selectStore,state => state.conversationEntityState)
export const selectConversationPage = createSelector(selectConversationEntityState,state => {
  var conversations = conversationAdapter.getSelectors().selectAll(state.conversationStates)
  if(conversations.length == 0)
    return { isLast : state.isLast, take : state.take, isDescending : state.isDescending, lastValue : undefined };
  var messages = messageAdapter
    .getSelectors()
    .selectAll(conversations[conversations.length - 1].messageEntityState.messageStates)
  if(messages.length == 0)
    return { isLast : state.isLast, take : state.take, isDescending : state.isDescending, lastValue : undefined };
  return { isLast : state.isLast, take : state.take, isDescending : state.isDescending, lastValue : messages[0].dateToDisplay };
});
export const selectConversationStates = createSelector(
  selectConversationEntityState,
  state => conversationAdapter.getSelectors().selectAll(state.conversationStates)
)
//*****************************************************************************************************

//*****************************************************************************************************
export const selectUserEntityState = createSelector(selectStore,state => state.userEntityState)
export const selectUserResponses = createSelector(
  selectUserEntityState,
  state => userAdapter.getSelectors().selectAll(state.users)
)
export const selectUserPage = createSelector(
  selectUserEntityState,
  state => {
    var users = userAdapter.getSelectors().selectAll(state.users);
    return {
      take : state.take,
      isLast : state.isLast,
      isDescending : state.isDescending,
      lastValue : users.length > 0 ? users[users.length - 1].userName : undefined,
    }
  }
)
//*****************************************************************************************************

//*****************************************************************************************************
export const selectMessageEntityState = (props : {userId : string}) => createSelector(
  selectConversationEntityState,
  state => state.conversationStates.entities[props.userId]?.messageEntityState
)
export const selectMessageStates = (props : {userId : string}) => createSelector(
  selectMessageEntityState(props),
  state => state ? messageAdapter.getSelectors().selectAll(state.messageStates) : []
)
export const selectCountOfNewMessages = (props : {userId : string}) => createSelector(
  selectMessageStates(props),
  state => state.filter(x => x.status != MessageStatus.Viewed && x.receiverId != props.userId).length
)
export const selectIdsOfUnViewedMessages = (props : {userId : string}) => createSelector(
  selectMessageStates(props),
  state => state.filter(x => x.status != MessageStatus.Viewed && x.receiverId != props.userId).map(m => m.id)
)
export const selectLastMessageState = (props : {userId : string}) => createSelector(
  selectMessageStates(props),
  state => state[0]
)
//*****************************************************************************************************
