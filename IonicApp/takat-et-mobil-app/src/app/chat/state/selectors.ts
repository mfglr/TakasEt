import { createFeatureSelector, createSelector, props } from "@ngrx/store";
import { ChatState, conversationAdapter, messageAdapter, selectAllMessageStates, takeValueOfMessage, userAdapter } from "./reducer";
import { MessageStatus } from "../models/responses/message-response";

export const selectStore = createFeatureSelector<ChatState>("ChatStore");
export const selectIsConnected = createSelector(selectStore,state => state.isConnected);
export const selectConversationEntityState = createSelector(selectStore,state => state.conversationEntityState)
export const selectConversationStates = createSelector(
  selectConversationEntityState,
  state => conversationAdapter.getSelectors().selectAll(state.conversationStates)
)
export const selectConversationState = (props : {userId : string}) => createSelector(
  selectConversationEntityState,
  state => state.conversationStates.entities[props.userId]
)
export const selectForConversationPage = (props : {userId : string}) => createSelector(
  selectConversationState(props),
  state => !state ? undefined : {
    userState : state.userState,
    messages : selectAllMessageStates(state.messageEntityState.messageStates)
  }
)
export const selectConversationList = createSelector(
  selectConversationStates,
  state => state.map(conversationState => ({
    userState : conversationState.userState,
    countOfUnviewedMessages :
      selectAllMessageStates(conversationState.messageEntityState.messageStates)
      .filter(messageState => messageState.senderId == conversationState.userId)
      .length,
    lastMessage : selectAllMessageStates(conversationState.messageEntityState.messageStates)[0]
  }))
)
export const selectConversationPage = createSelector(selectConversationEntityState,state => {
  var conversations = conversationAdapter.getSelectors().selectAll(state.conversationStates)
  if(conversations.length == 0)
    return { isLast : state.isLast, take : state.take, isDescending : state.isDescending, lastValue : undefined };
  var messages = messageAdapter
    .getSelectors()
    .selectAll(conversations[conversations.length - 1].messageEntityState.messageStates)
  if(messages.length == 0)
    return { isLast : state.isLast, take : state.take, isDescending : state.isDescending, lastValue : undefined };
  return { isLast : state.isLast, take : state.take, isDescending : state.isDescending, lastValue : messages[0].sendDate };
});


//*****************************************************************************************************
export const selectUserEntityState = createSelector(selectStore,state => state.userEntityState)
export const selectUserStates = createSelector(
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
  selectConversationState(props),
  state => state ? state.messageEntityState : {
    isLast : true,
    isDescending : true,
    take : takeValueOfMessage,
    messageStates : messageAdapter.getInitialState()
  }
)
export const selectMessagePage = (props : {userId : string}) => createSelector(
  selectMessageEntityState(props),
  state => {
    var messageStates = selectAllMessageStates(state.messageStates);
    return {
      isLast : state.isLast,
      isDescending : state.isDescending,
      take : state.take,
      lastValue : messageStates.length > 0 ? messageStates[messageStates.length - 1].sendDate : undefined
    }
  }
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
