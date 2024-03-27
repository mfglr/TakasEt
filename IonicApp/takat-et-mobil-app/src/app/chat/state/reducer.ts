import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { MessageStatus } from "../models/responses/message-response";
import { createReducer, on } from "@ngrx/store";
import {
  receiveMessageAction, createMessageSuccessAction,loadMessageImageSuccessAction,
  nextPageMessagesSuccessAction, nextPageConversationsSuccessAction, nextPageUsersSuccessAction,
  loadConversationUserSuccessAction, createMessageAction, changeHubConnectionStateAction,
  markMessageSentAsReceivedAction, markMessageSentAsViewedAction, viewMessageAction
} from "./actions";
import { UserImageResponse } from "src/app/models/responses/user-image-response";
import { HubConnectionState } from "@microsoft/signalr";
import { ImageLoadingState } from "src/app/models/enums/image-loading-state";

export const numberOfMessagesPerPage = 50;
export const numberOfConversationsPerPage = 20;
export const numberOfUserPerPage = 20;

export interface Pagination{
  isDescending : boolean;
  take : number;
  isLast : boolean;
  lastValue? : string | number | Date
}
export interface MessagePagination extends Pagination{
  userId : string;
}
export const messagePaginationAdapter = createEntityAdapter<MessagePagination>({
  selectId : state => state.userId
});

export interface UserState{
  id : string;
  createdDate? : Date;
  updatedDate? : Date;
  userName : string;
  email : string;
	name? : string
	lastName? : string;
  fullName? : string;
	countOfFollowings : number;
	countOfFollowers : number;
  countOfPosts : number;
  isFollower : boolean;
  isFollowing : boolean;
	images : UserImageResponse[];
}
export const userAdapter = createEntityAdapter<UserState>({
  selectId : state => state.id,
  sortComparer : (x,y) => x.userName.localeCompare(y.userName)
})
export const selectUserStates = userAdapter.getSelectors().selectAll;

export interface MessageImageState{
  id? : string;
  blobName? : string;
  extention? : string;
  height? : number;
  width? : number;
  aspectRatio? : number;
  url? : string | undefined;
  status : ImageLoadingState;
}
export interface MessageState{
  timeStamp : number;
  sendDate : Date;
  receivedDate? : Date;
  viewedDate? : Date;
  id : string;
  senderId : string;
  receiverId : string;
  content? : string;
  status : MessageStatus;
  images? : MessageImageState[]
}
export const messageAdapter = createEntityAdapter<MessageState>({
  selectId : state => state.id,
  sortComparer : (x,y) => x.timeStamp < y.timeStamp ? 1 : -1
})
export const selectMessageStates = messageAdapter.getSelectors().selectAll;

export interface DateOfMessageState{
  messageId : string,
  timeStamp : number;
}
export const dateOfMessageStateAdapter = createEntityAdapter<DateOfMessageState>({
  selectId : state => state.messageId,
  sortComparer : (x,y) => x.timeStamp < y.timeStamp ? 1 : -1
});
export const selectDateOfMessageStates = dateOfMessageStateAdapter.getSelectors().selectAll;

export interface ConversationState{
  userId : string;
  userState? : UserState;
  dateOfMessageEntityState : EntityState<DateOfMessageState>,
}
export const conversationAdapter = createEntityAdapter<ConversationState>({
  selectId : state => state.userId,
  sortComparer : (x,y) =>{
    let xdates = selectDateOfMessageStates(x.dateOfMessageEntityState)
    let xdate = xdates.length > 0 ? xdates[0].timeStamp : new Date(1900).getTime();

    let ydates = selectDateOfMessageStates(y.dateOfMessageEntityState)
    let ydate = ydates.length > 0 ? ydates[0].timeStamp : new Date(1900).getTime();

    return xdate < ydate ? 1 : -1
  }
})
export const selectConversationStates = conversationAdapter.getSelectors().selectAll

export interface ChatState{
  loginUserId? : string | undefined;
  hubConnectionState : HubConnectionState;
  userEntityState : EntityState<UserState>;
  messageEntityState : EntityState<MessageState>;
  conversationEntityState : EntityState<ConversationState>;
  userPagination : Pagination;
  conversationPagination : Pagination;
  messagePaginationEntityState : EntityState<MessagePagination>;
}

const initialState : ChatState = {
  hubConnectionState : HubConnectionState.Connecting,
  conversationPagination : {isDescending : true,isLast : false,take : numberOfConversationsPerPage},
  userPagination : {isDescending : false,isLast : false,take : numberOfUserPerPage},
  messagePaginationEntityState : messagePaginationAdapter.getInitialState(),
  userEntityState : userAdapter.getInitialState(),
  conversationEntityState : conversationAdapter.getInitialState(),
  messageEntityState : messageAdapter.getInitialState(),
}

export const chatReducer = createReducer(
  initialState,
  on(changeHubConnectionStateAction,(state,action) => ({...state,hubConnectionState : action.payload})),
  on(createMessageAction,(state,action) => {
    let conversationState = state.conversationEntityState.entities[action.message.receiverId]
    return {
      ...state,
      conversationEntityState : conversationAdapter.setOne({
        userId : action.message.receiverId,
        userState : action.userState,
        dateOfMessageEntityState : dateOfMessageStateAdapter.addOne(
          {messageId : action.message.id, timeStamp : action.message.sendDate },
          conversationState?.dateOfMessageEntityState ?? dateOfMessageStateAdapter.getInitialState()
        )
      },state.conversationEntityState),
      messageEntityState : messageAdapter.addOne({
        ...action.message,
        timeStamp : action.message.sendDate,
        status : MessageStatus.NotCreated,
        senderId : action.senderId,
        sendDate : new Date(action.message.sendDate),
        images : action.paths.map(path => ({
          status : ImageLoadingState.loaded,
          url : path.webPath
        })),
      },state.messageEntityState),
      messagePaginationEntityState : messagePaginationAdapter.addOne({
        userId : action.message.receiverId,
        isDescending : true,
        isLast : false,
        take : numberOfMessagesPerPage,
      },state.messagePaginationEntityState),
    }
  }),
  on(createMessageSuccessAction,(state,action) => ({
    ...state,
    messageEntityState : messageAdapter.updateOne({
      id : action.payload.id,
      changes : {
        status : MessageStatus.Created,
        images : action.payload.images?.map((image,i) => ({
          ...image,
          ...state.messageEntityState.entities[action.payload.id]!.images![i],
        }))
      }
    },state.messageEntityState)
  })),
  on(receiveMessageAction,(state,action) => ({
      ...state,
      conversationEntityState : conversationAdapter.setOne({
        userId : action.payload.senderId,
        userState : state.conversationEntityState.entities[action.payload.senderId]?.userState,
        dateOfMessageEntityState : dateOfMessageStateAdapter.addOne(
          {messageId : action.payload.id, timeStamp : action.receivedDate.getTime()},
          state.conversationEntityState.entities[action.payload.senderId]?.dateOfMessageEntityState ??
            dateOfMessageStateAdapter.getInitialState())},
        state.conversationEntityState
      ),
      messageEntityState : messageAdapter.addOne({
        ...action.payload,
        status : MessageStatus.Received,
        receivedDate : action.receivedDate,
        timeStamp : action.receivedDate.getTime(),
        images : action.payload.images?.map(image => ({...image,status : ImageLoadingState.notLoaded}))
      },state.messageEntityState),
      messagePaginationEntityState : messagePaginationAdapter.addOne({
        userId : action.payload.senderId,
        isDescending : true,
        isLast : false,
        take : numberOfMessagesPerPage,
      },state.messagePaginationEntityState)
    })
  ),
  on(viewMessageAction, (state,action) => ({
    ...state,
    messageEntityState : messageAdapter.updateOne({
      id : action.id,
      changes : { viewedDate : action.viewedDate, status : MessageStatus.Viewed }
    },state.messageEntityState)
  })),
  on(markMessageSentAsReceivedAction,(state,action) => {
    let messageEntityState;
    let messageState = state.messageEntityState.entities[action.messageId];
    if(messageState == null)
      return state;
    if(messageState.status == MessageStatus.Received)
        messageEntityState = state.messageEntityState
    else if(messageState.status == MessageStatus.Viewed)
      messageEntityState = messageAdapter.updateOne({
        id : action.messageId,
        changes : {
          receivedDate : messageState.receivedDate ?? action.receivedDate
        }
      },state.messageEntityState)
    else
      messageEntityState = messageAdapter.updateOne({
        id : action.messageId,
        changes : {
          receivedDate : action.receivedDate,
          status : MessageStatus.Received
        }
      },state.messageEntityState)
    return {
      ...state,
      messageEntityState : messageEntityState
    }
  }),
  on(markMessageSentAsViewedAction,(state,action) => {
    let messageEntityState;
    let messageState = state.messageEntityState.entities[action.messageId];
    if(messageState == null)
      return state;
    if(messageState.status == MessageStatus.Received)
      messageEntityState = messageAdapter.updateOne({
        id : action.messageId,
        changes : {
          status : MessageStatus.Viewed,
          viewedDate : messageState.viewedDate ?? action.viewedDate
        }
      },state.messageEntityState)
    else if(messageState.status == MessageStatus.Viewed)
      messageEntityState = state.messageEntityState
    else
      messageEntityState = messageAdapter.updateOne({
        id : action.messageId,
        changes : {
          viewedDate : action.viewedDate,
          status : MessageStatus.Viewed
        }
      },state.messageEntityState)
    return {
      ...state,
      messageEntityState : messageEntityState
    }
  }),
  on(nextPageUsersSuccessAction, (state,action) => ({
    ...state,
    userPagination : {...state.userPagination,isLast : action.payload.length < numberOfUserPerPage},
    userEntityState : userAdapter.addMany(
      action.payload.map((user) : UserState => ({...user})),
      state.userEntityState
    ),
    messagePaginationEntityState : messagePaginationAdapter.addMany(
      action.payload.map((x) : MessagePagination =>({
        userId : x.id,
        isDescending : true,
        isLast : false,
        take : numberOfMessagesPerPage,
      })),
      state.messagePaginationEntityState
    )
  })),
  on(loadConversationUserSuccessAction,(state,action) => {
    let conversationEntityState;
    var conversationState = state.conversationEntityState.entities[action.payload.id]

    if(conversationState)
      conversationEntityState = conversationAdapter.updateOne({
        id : action.payload.id,
        changes : { userState : action.payload }
      },state.conversationEntityState)
    else
      conversationEntityState = conversationAdapter.addOne({
        userId : action.payload.id,
        userState : action.payload,
        dateOfMessageEntityState : dateOfMessageStateAdapter.getInitialState()
      },state.conversationEntityState)

    return { ...state, conversationEntityState : conversationEntityState }
  }),
  on(nextPageConversationsSuccessAction,(state,action) => {

    let messageEntityState : EntityState<MessageState> = state.messageEntityState;
    for(let i = 0; i < action.payload.length; i++){
      messageEntityState = messageAdapter.addMany(
        action.payload[i].messages.map(message => ({
          ...message,
          timeStamp : action.payload[i].userId == message.senderId ? message.receivedDate!.getTime() : message.sendDate.getTime(),
          images : message.images?.map((image ) : MessageImageState => ({
            ...image,
            status : ImageLoadingState.notLoaded,
          }))
        })),
        messageEntityState
      )
    }
    return {
      ...state,
      conversationPagination : {
        ...state.conversationPagination,
        isLast : action.payload.length < numberOfConversationsPerPage
      },
      conversationEntityState : conversationAdapter.setMany(
        action.payload.map((c) : ConversationState =>({
          userId : c.userId,
          userState : state.conversationEntityState.entities[c.userId]?.userState ?? undefined,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addMany(
            c.messages.map(m => ({
              messageId : m.id,
              timeStamp : c.userId == m.senderId ? m.receivedDate!.getTime() : m.sendDate.getTime()
            })),
            state.conversationEntityState.entities[c.userId]?.dateOfMessageEntityState ??
              dateOfMessageStateAdapter.getInitialState()
          )
        })),
        state.conversationEntityState
      ),
      messageEntityState : messageEntityState,
      messagePaginationEntityState : messagePaginationAdapter.setMany(
        action.payload.map((m) : MessagePagination => ({
          userId : m.userId,
          isDescending : true,
          take : numberOfMessagesPerPage,
          isLast : m.messages.length < numberOfMessagesPerPage,
        })),
        state.messagePaginationEntityState
      )
    }
  }),
  on(nextPageMessagesSuccessAction,(state,action) => ({
    ...state,
    conversationEntityState : conversationAdapter.setOne({
      userId : action.user.id,
      userState : state.conversationEntityState.entities[action.user.id]?.userState,
      dateOfMessageEntityState : dateOfMessageStateAdapter.addMany(
        action.payload.map(x => ({
          messageId : x.id,
          timeStamp : x.senderId == action.user.id ? x.receivedDate!.getTime() : x.sendDate.getTime()
        })),
        state.conversationEntityState.entities[action.user.id]?.dateOfMessageEntityState ??
          dateOfMessageStateAdapter.getInitialState()
      )
    },state.conversationEntityState),
    messageEntityState : messageAdapter.addMany(
      action.payload.map((x,i) => ({
        ...x,
        timeStamp : x.senderId == action.user.id ? x.receivedDate!.getTime() : x.sendDate.getTime(),
        images : x.images?.map((image) : MessageImageState => ({
          ...image,
          status : ImageLoadingState.notLoaded
        }))
      })),
      state.messageEntityState
    ),
    messagePaginationEntityState : messagePaginationAdapter.updateOne({
      id : action.user.id,
      changes : {isLast : action.payload.length < numberOfMessagesPerPage}
    },state.messagePaginationEntityState)
  })),
  on(loadMessageImageSuccessAction,(state,action) => ({
    ...state,
    messageEntityState : messageAdapter.updateOne({
      id : action.id,
      changes : {
        images : [...state.messageEntityState.entities[action.id]!.images!].map((image,index) => {
          if(index == action.imageIndex)
            return {...image, status : ImageLoadingState.loaded, url : action.url }
          return image;
        })
      }
    },state.messageEntityState)

  })),
)

