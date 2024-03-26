import { createFeatureSelector, createSelector, select } from "@ngrx/store";
import { ChatState, selectConversationStates, selectMessageStates, selectUserStates, numberOfMessagesPerPage } from "./reducer";
import { MessageStatus } from "../models/responses/message-response";


export const selectStore = createFeatureSelector<ChatState>("ChatStore");
export const selectHubConnectionState = createSelector(selectStore,state => state.hubConnectionState);
export const selectConversationState = (props : {userId : string}) => createSelector(
  selectStore,
  state => state.conversationEntityState.entities[props.userId]
)
export const selectConversationPagination = createSelector(
  selectStore,
  state => {
    var messages = selectMessageStates(state.messageEntityState);
    return {
      ...state.conversationPagination,
      lastValue : messages.length > 0 ? messages[messages.length - 1].sendDate.getTime() : undefined
    }
  }
)
export const selectNewMessages = createSelector(
  selectStore,
  state => selectMessageStates(state.messageEntityState)
    .filter(x => x.status == MessageStatus.Created && x.senderId == state.loginUserId!)
)
export const selectForChatHomePage = createSelector(
  selectStore,
  state => selectConversationStates(state.conversationEntityState).map(x => {
    var messages = selectMessageStates(state.messageEntityState)
      .filter(
        m => m.senderId == x.userId || m.receiverId == x.userId
      );
    return {
      userId : x.userId,
      userState : x.userState,
      countOfUnviewedMessages : messages
        .filter(m => m.senderId == x.userId && m.status != MessageStatus.Viewed).length,
      lastMessage : messages.length > 0 ? messages[0] : undefined
    }
  })
)
export const selectMessageStatesOfConversatinPage = (props : {userId : string}) => createSelector(
  selectStore,
  state => selectMessageStates(state.messageEntityState)
    .filter(x => x.senderId == props.userId || x.receiverId == props.userId)
)
export const selectUnviewedMessages = (props : {userId : string}) => createSelector(
  selectStore,
  state => selectMessageStates(state.messageEntityState)
    .filter(x => x.senderId == props.userId && x.status != MessageStatus.Viewed)
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

    let lastValue
    if(messages.length > 0){
      let lastMessage = messages[messages.length - 1];
      lastValue = props.userId == lastMessage.senderId ?
        lastMessage.receivedDate!.getTime() :
        lastMessage.sendDate.getTime()
    }
    else
      lastValue = undefined;

    if(pagination)
      return { ...pagination, lastValue : lastValue }
    return {
      userId : props.userId,
      isDescending : true,
      isLast : false,
      lastValue : lastValue,
      take : numberOfMessagesPerPage
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
const selectMessageState = (props : {messageId : string}) => createSelector(
  selectStore,
  state => state.messageEntityState.entities[props.messageId]
)
export const selectImageLoadStatus = (props : {messageId : string,index : number}) => createSelector(
  selectMessageState(props),
  state => state!.images![props.index].status
)
