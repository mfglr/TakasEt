import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ChatState, selectConversationStates, selectMessageStates, selectUserStates, takeValueOfMessage } from "./reducer";
import { MessageStatus } from "../models/responses/message-response";

export const selectStore = createFeatureSelector<ChatState>("ChatStore");
export const selectIsConnected = createSelector(selectStore,state => state.isConnected);
export const selectConversationPagination = createSelector(
  selectStore,
  state => {
    var messages = selectMessageStates(state.messageEntityState);
    return {
      ...state.conversationPagination,
      lastValue : messages.length > 0 ? messages[messages.length - 1].sendDate : undefined
    }
  }
)
export const selectForChatHomePage = createSelector(
  selectStore,
  state => selectConversationStates(state.conversationEntityState).map(x => ({
    userState : x.userState,
    countOfUnviewedMessages : selectMessageStates(state.messageEntityState)
      .filter(m => m.senderId == x.userId && m.status != MessageStatus.Viewed).length,
    lastMessage : selectMessageStates(state.messageEntityState)[0]
  }))
)
export const selectMessageStatesOfConversatinPage = (props : {userId : string}) => createSelector(
  selectStore,
  state => selectMessageStates(state.messageEntityState)
    .filter(x => x.senderId == props.userId || x.receiverId == props.userId)
)
export const selectUserPagination = createSelector(
  selectStore,
  state => {
    var users = selectUserStates(state.userEntityState)
    return {
      ...state.userPagination,
      lastValue : users.length > 0 ? users[users.length - 1].userName : undefined
    }
  }
)
export const selectMessagePagination = (props:{userId : string}) => createSelector(
  selectStore,
  state => {
    var pagination = state.messagePaginationEntityState.entities[props.userId]
    var messages = selectMessageStates(state.messageEntityState)
    var lastValue = messages.length > 0 ? messages[messages.length - 1].sendDate : undefined;
    if(pagination)
      return { ...pagination, lastValue : lastValue }
    return {
      userId : props.userId,
      isDescending : true,
      isLast : false,
      lastValue : lastValue,
      take : takeValueOfMessage
    }
  }
)
export const selectMessage = (props : {messageId : string}) => createSelector(
  selectStore,
  state => state.messageEntityState.entities[props.messageId]
)

export const selectUsers = createSelector(
  selectStore,
  state => selectUserStates(state.userEntityState)
)
