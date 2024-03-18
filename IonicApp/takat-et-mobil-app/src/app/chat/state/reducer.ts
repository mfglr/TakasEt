import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { MessageStatus } from "../models/responses/message-response";
import { createReducer, on } from "@ngrx/store";
import {
  markMessageAsCreatedSuccessAction, markMessageAsReceivedSuccessAction, markMessageSentAsViewedAction,
  markMessagesSentAsViewedAction, receiveMessageSuccessAction, sendMessageSuccessAction,
  nextPageMessagesSuccessAction, nextPageConversationsSuccessAction, connectionFailedAction,
  connectionSuccessAction, nextPageUsersSuccessAction, loadNewMessagesSuccessAction,
  markMessagesAsReceivedSuccessAction, loadConversationUserSuccessAction, synchronizedSuccessAction,
  synchronizedFailedAction, markMessagesReceivedAsViewedAction, markMessageReceivedAsViewedAction,
} from "./actions";
import { MessageImageResponse } from "../models/responses/message-image-response";
import { UserImageResponse } from "src/app/models/responses/user-image-response";
import { ConversationResponse } from "../models/responses/conversation-response";

export const takeValueOfMessage = 50;
export const takeValueOfConversation = 20;
export const takeValueOfUser = 20;

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

export interface MessageState{
  timeStamp : number;
  sendDate : Date;
  updatedDate? : Date;
  createdDate? : Date;
  receivedDate? : Date;
  viewedDate? : Date;
  id : string;
  senderId : string;
  receiverId : string;
  content : string;
  status : MessageStatus;
  images? : MessageImageResponse[]
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
  isSynchronized : boolean;
  isConnected : boolean;
  userEntityState : EntityState<UserState>;
  messageEntityState : EntityState<MessageState>;
  conversationEntityState : EntityState<ConversationState>;
  userPagination : Pagination;
  conversationPagination : Pagination;
  messagePaginationEntityState : EntityState<MessagePagination>;
}

const initialState : ChatState = {
  isSynchronized : false,
  isConnected : false,
  conversationPagination : {isDescending : true,isLast : false,take : takeValueOfConversation},
  userPagination : {isDescending : false,isLast : false,take : takeValueOfUser},
  messagePaginationEntityState : messagePaginationAdapter.getInitialState(),
  userEntityState : userAdapter.getInitialState(),
  conversationEntityState : conversationAdapter.getInitialState(),
  messageEntityState : messageAdapter.getInitialState()
}

export const chatReducer = createReducer(
  initialState,
  on( connectionFailedAction, state => ({...state, isConnected : false,isSynchronized : false}) ),

  on( connectionSuccessAction, state => ({...state, isConnected : true}) ),

  on( synchronizedSuccessAction,state => ({...state, isSynchronized : true})),

  on( synchronizedFailedAction ,state => ({...state, isSynchronized : false})),

  on(nextPageUsersSuccessAction, (state,action) => ({
    ...state,
    userPagination : {...state.userPagination,isLast : action.payload.length < takeValueOfUser},
    userEntityState : userAdapter.addMany(
      action.payload.map((user) : UserState => ({...user})),
      state.userEntityState
    ),
    messagePaginationEntityState : messagePaginationAdapter.addMany(
      action.payload.map((x) : MessagePagination =>({
        userId : x.id,
        isDescending : true,
        isLast : false,
        take : takeValueOfMessage,
      })),
      state.messagePaginationEntityState
    )
  })),

  on(loadNewMessagesSuccessAction,(state,action) => ({
    ...state,
    conversationEntityState : conversationAdapter.setMany(
      action.payload.map((m) : ConversationState => {
        let dateOfMessageState = {
          messageId : m.id,
          timeStamp : m.receivedDate?.getTime() ?? action.receivedDate.getTime()
        }
        let conversationState = state.conversationEntityState.entities[m.senderId];
        if(conversationState)
          return {
            ...conversationState,
            dateOfMessageEntityState : dateOfMessageStateAdapter.addOne(
              dateOfMessageState,conversationState.dateOfMessageEntityState
            )
          }
        return {
          userId : m.senderId,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne(
            dateOfMessageState,dateOfMessageStateAdapter.getInitialState()
          )
        }
      }),
      state.conversationEntityState
    ),

    messageEntityState : messageAdapter.addMany(action.payload.map((m) : MessageState => ({
      ...m,
      receivedDate : m.receivedDate ?? action.receivedDate,
      status : MessageStatus.Received,
      timeStamp : m.receivedDate?.getTime() ?? action.receivedDate.getTime(),
    })),state.messageEntityState),

    messagePaginationEntityState : messagePaginationAdapter.addMany(
      action.payload.map((m) : MessagePagination => ({
        userId : m.senderId,
        isDescending : true,
        isLast : false,
        take : takeValueOfMessage,
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

  on(nextPageConversationsSuccessAction,(state,action) => ({
    ...state,
    conversationPagination : {
      ...state.conversationPagination,
      isLast : action.payload.length < takeValueOfConversation
    },
    conversationEntityState : conversationAdapter.setMany(
      action.payload.map((c) : ConversationState =>{
        var conversationState = state.conversationEntityState.entities[c.userId]
        if(conversationState)
          return {
            ...conversationState,
            dateOfMessageEntityState : dateOfMessageStateAdapter.addMany(
              c.messages.map(m => ({
                messageId : m.id,
                timeStamp :
                  c.userId == m.senderId ?
                    m.receivedDate ?
                      m.receivedDate.getTime() :
                      action.receivedDate.getTime() :
                    m.sendDate.getTime()
              })),
              conversationState.dateOfMessageEntityState
            )
          }
        return {
          userId : c.userId,
          userState : c.user ? {...c.user} : undefined,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addMany(
            c.messages.map(m => ({
              messageId : m.id,
              timeStamp :
                  c.userId == m.senderId ?
                    m.receivedDate ?
                      m.receivedDate.getTime() :
                      action.receivedDate.getTime() :
                    m.sendDate.getTime()
            })),
            dateOfMessageStateAdapter.getInitialState()
          )
        }
      }),
      state.conversationEntityState
    ),
    messageEntityState : AddMessages(action.payload,state.messageEntityState,action.receivedDate),
    messagePaginationEntityState : messagePaginationAdapter.setMany(
      action.payload.map((m) : MessagePagination => ({
        userId : m.userId,
        isDescending : true,
        take : takeValueOfMessage,
        isLast : m.messages.length < takeValueOfMessage,
      })),
      state.messagePaginationEntityState
    )
  })),

  on(nextPageMessagesSuccessAction,(state,action) => {
    let timeStamps = action.payload.map(
      x => x.senderId == action.user.id ? x.receivedDate!.getTime() : x.sendDate.getTime()
    )
    let conversationEntityState = state.conversationEntityState;
    let conversationState = state.conversationEntityState.entities[action.user.id]
    if(conversationState){
      conversationEntityState = conversationAdapter.updateOne({
        id : action.user.id,
        changes : {
          dateOfMessageEntityState : dateOfMessageStateAdapter.addMany(
            action.payload.map((x,i) => ({messageId : x.id,timeStamp : timeStamps[i]})),
            conversationState.dateOfMessageEntityState
          )
        }
      },conversationEntityState)
    }
    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState : messageAdapter.addMany(
        action.payload.map((m,i) => ({...m,timeStamp : timeStamps[i]})),
        state.messageEntityState
      ),
      messagePaginationEntityState : messagePaginationAdapter.updateOne({
        id : action.user.id,
        changes : {isLast : action.payload.length < takeValueOfMessage}
      },state.messagePaginationEntityState)
    }
  }),

  on(sendMessageSuccessAction,(state,action) => {

    var messageEntityState = messageAdapter.addOne({
      ...action.request,
      timeStamp : action.request.sendDate,
      sendDate : new Date(action.request.sendDate),
      status : MessageStatus.NotCreated,
    },state.messageEntityState)

    let messagePaginationEntityState = messagePaginationAdapter.addOne({
      userId : action.request.receiverId,
      isDescending : true,
      isLast : false,
      take : takeValueOfMessage,
    },state.messagePaginationEntityState)

    let conversationEntityState;
    let conversationState = state.conversationEntityState.entities[action.request.receiverId]
    let dateOfMessageState = {messageId : action.request.id, timeStamp : action.request.sendDate }
    if(conversationState){
      conversationEntityState = conversationAdapter.updateOne({
        id : action.request.receiverId,
        changes : {
          userState : conversationState.userState ? conversationState.userState : action.userState,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne(
            dateOfMessageState,
            conversationState.dateOfMessageEntityState
          )
        }
      },state.conversationEntityState)
    }
    else{
      conversationEntityState = conversationAdapter.addOne({
        userId : action.request.receiverId,
        userState : action.userState,
        dateOfMessageEntityState : dateOfMessageStateAdapter.addOne(
          dateOfMessageState,
          dateOfMessageStateAdapter.getInitialState()
        )
      },state.conversationEntityState)
    }
    return {
      ...state,
      messageEntityState : messageEntityState,
      conversationEntityState : conversationEntityState,
      messagePaginationEntityState : messagePaginationEntityState,
    }
  }),

  on(markMessageAsCreatedSuccessAction,(state,action) => {
    let messageEntityState;
    let messageState = state.messageEntityState.entities[action.message.id];
    if(messageState){
      if(messageState.status == MessageStatus.Created)
        messageEntityState = state.messageEntityState;
      else if(messageState.status == MessageStatus.Received || messageState.status == MessageStatus.Viewed)
        messageEntityState = messageAdapter.updateOne({
          id : action.message.id,
          changes : {
            createdDate : messageState.createdDate ?? action.message.createdDate
          }
        },state.messageEntityState)
      else
        messageEntityState = messageAdapter.updateOne({
          id : action.message.id,
          changes : {
            createdDate : messageState.createdDate ?? action.message.createdDate,
            status : MessageStatus.Created
          }
        },state.messageEntityState)
    }
    else
      messageEntityState = messageAdapter.addOne({
        ...action.message,
        timeStamp : action.message.sendDate.getTime()
      },state.messageEntityState)

    let messagePaginationEntityState = state.messagePaginationEntityState;
    let messagePagination = state.messagePaginationEntityState.entities[action.message.receiverId]
    if(!messagePagination)
      messagePaginationEntityState = messagePaginationAdapter.addOne({
        userId : action.message.receiverId,
        isDescending : true,
        isLast : false,
        take : takeValueOfMessage,
      },messagePaginationEntityState)

    let conversationEntityState;
    let conversationState = state.conversationEntityState.entities[action.message.receiverId];
    if(conversationState)
      conversationEntityState = conversationAdapter.updateOne({
        id : action.message.receiverId,
        changes :{
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : action.message.id,
            timeStamp : action.message.sendDate.getTime()
          },conversationState.dateOfMessageEntityState)
        }
      },state.conversationEntityState)
    else{
      conversationEntityState = conversationAdapter.addOne({
        userId : action.message.receiverId,
        dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
          messageId : action.message.id,
          timeStamp : action.message.sendDate.getTime()
        },dateOfMessageStateAdapter.getInitialState())
      },state.conversationEntityState)
    }
    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState : messageEntityState,
      messagePaginationEntityState : messagePaginationEntityState
    }
  }),

  on(receiveMessageSuccessAction,(state,action) => {
    let conversationEntityState;
    var conversationState = state.conversationEntityState.entities[action.payload.senderId]
    if(conversationState){
      conversationEntityState = conversationAdapter.updateOne({
        id : action.payload.senderId,
        changes : {
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : action.payload.id,timeStamp : action.payload.receivedDate!.getTime()
          },conversationState.dateOfMessageEntityState)
        }
      },state.conversationEntityState)
    }
    else{
      conversationEntityState = conversationAdapter.addOne(
        {
          userId : action.payload.senderId,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : action.payload.id,timeStamp : action.payload.receivedDate!.getTime()
          },dateOfMessageStateAdapter.getInitialState())
        },
        conversationAdapter.getInitialState()
      )
    }

    let messageEntityState;
    let messageState = state.messageEntityState.entities[action.payload.senderId]
    if(messageState){
      if(messageState.status == MessageStatus.Received)
        messageEntityState = state.messageEntityState;
      else if(messageState.status == MessageStatus.Viewed)
        messageEntityState = messageAdapter.updateOne({
          id : action.payload.id,
          changes : {
            receivedDate : messageState.receivedDate ? messageState.receivedDate : action.payload.receivedDate
          }
        },state.messageEntityState)
      else
        messageEntityState = messageAdapter.updateOne({
          id : action.payload.id,
          changes : {
            status : MessageStatus.Received,
            receivedDate : action.payload.receivedDate
          }
        },state.messageEntityState)
    }
    else{
      messageEntityState = messageAdapter.addOne({
        ...action.payload,
        timeStamp : action.payload.receivedDate!.getTime(),
        status : MessageStatus.Received
      },state.messageEntityState)
    }
    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState :messageEntityState,
      messagePaginationEntityState : messagePaginationAdapter.addOne({
        userId : action.payload.senderId,
        isDescending : true,
        isLast : false,
        take : takeValueOfMessage,
      },state.messagePaginationEntityState)
    }
  }),

  on(markMessageAsReceivedSuccessAction,(state,action) => {
    let messageEntityState;
    let messageState = state.messageEntityState.entities[action.payload.id];
    if(messageState){
      if(messageState.status == MessageStatus.Received)
        messageEntityState = state.messageEntityState
      else if(messageState.status == MessageStatus.Viewed)
        messageEntityState = messageAdapter.updateOne({
          id : action.payload.id,
          changes : {
            receivedDate : messageState.receivedDate ?? action.payload.receivedDate!
          }
        },state.messageEntityState)
      else
        messageEntityState = messageAdapter.updateOne({
          id : action.payload.id,
          changes : {
            updatedDate : action.payload.updatedDate,
            receivedDate : action.payload.receivedDate,
            status : MessageStatus.Received
          }
        },state.messageEntityState)
    }
    else{
      messageEntityState = messageAdapter.addOne({
        ...action.payload,
        timeStamp : action.payload.sendDate.getTime()
      },state.messageEntityState)
    }


    let messagePaginationEntityState = state.messagePaginationEntityState;
    let messagePagination = state.messagePaginationEntityState.entities[action.payload.receiverId]
    if(!messagePagination)
      messagePaginationEntityState = messagePaginationAdapter.addOne({
        userId : action.payload.receiverId,
        isDescending : true,
        isLast : false,
        take : takeValueOfMessage,
      },messagePaginationEntityState)

    let conversationEntityState;
    let conversationState = state.conversationEntityState.entities[action.payload.receiverId];
    if(conversationState)
      conversationEntityState = conversationAdapter.updateOne({
        id : action.payload.receiverId,
        changes :{
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : action.payload.id,
            timeStamp : action.payload.sendDate.getTime()
          },conversationState.dateOfMessageEntityState)
        }
      },state.conversationEntityState)
    else
      conversationEntityState = conversationAdapter.addOne({
        userId : action.payload.receiverId,
        dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
          messageId : action.payload.id,
          timeStamp : action.payload.sendDate.getTime()
        },dateOfMessageStateAdapter.getInitialState())
      },state.conversationEntityState)

    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState : messageEntityState,
      messagePaginationEntityState : messagePaginationEntityState
    }
  }),

  on(markMessagesAsReceivedSuccessAction,(state,action) => {

    let conversationEntityState = state.conversationEntityState;
    let messageEntityState = state.messageEntityState;
    let messagePaginationEntityState = state.messagePaginationEntityState;

    for(let i = 0; i < action.payload.length;i++){

      let message = action.payload[i];

      let conversationState = conversationEntityState.entities[message.receiverId];
      if(conversationState)
        conversationEntityState = conversationAdapter.updateOne({
          id : message.receiverId,
          changes : {
            dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
              messageId : message.id,timeStamp : message.sendDate.getTime()
            },conversationState.dateOfMessageEntityState)
          }
        },conversationEntityState)
      else
        conversationEntityState = conversationAdapter.addOne({
          userId : message.receiverId,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : message.id,timeStamp : message.sendDate.getTime()
          },dateOfMessageStateAdapter.getInitialState())
        },conversationEntityState)

      let messageState = messageEntityState.entities[message.id];
      if(messageState){
        if(messageState.status == MessageStatus.Received)
          messageEntityState = state.messageEntityState
        else if(messageState.status == MessageStatus.Viewed)
          messageEntityState = messageAdapter.updateOne({
            id : message.id,
            changes : { receivedDate : messageState.receivedDate ?? message.receivedDate }
          },state.messageEntityState)
        else
          messageEntityState = messageAdapter.updateOne({
            id : message.id,
            changes : {
              updatedDate : message.updatedDate,
              receivedDate : message.receivedDate,
              status : MessageStatus.Received
            }
          },state.messageEntityState)
      }
      else
        messageEntityState = messageAdapter.addOne({
          ...message, timeStamp : message.sendDate.getTime()
        },messageEntityState)

      let messagePagination = state.messagePaginationEntityState.entities[message.receiverId]
      if(!messagePagination)
        messagePaginationEntityState = messagePaginationAdapter.addOne({
          userId : message.receiverId,
          isDescending : true,
          isLast : false,
          take : takeValueOfMessage,
        },messagePaginationEntityState)
    }

    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState : messageEntityState,
      messagePaginationEntityState : messagePaginationEntityState,
    }
  }),

  on(markMessageSentAsViewedAction,(state,action) => {
    let messageEntityState;
    let messageState = state.messageEntityState.entities[action.payload.id];
    if(messageState){
      if(messageState.status == MessageStatus.Viewed)
        messageEntityState = state.messageEntityState
      else
        messageEntityState = messageAdapter.updateOne({
          id : action.payload.id,
          changes : {
            viewedDate : messageState.viewedDate ?? action.payload.viewedDate!,
            status : MessageStatus.Viewed
          }
        },state.messageEntityState)
    }
    else
      messageEntityState = messageAdapter.addOne({
        ...action.payload,
        timeStamp : action.payload.sendDate.getTime()
      },state.messageEntityState)

    let messagePaginationEntityState = state.messagePaginationEntityState;
    let messagePagination = state.messagePaginationEntityState.entities[action.payload.receiverId]
    if(!messagePagination)
      messagePaginationEntityState = messagePaginationAdapter.addOne({
        userId : action.payload.receiverId,
        isDescending : true,
        isLast : false,
        take : takeValueOfMessage,
      },messagePaginationEntityState)

    let conversationEntityState;
    let conversationState = state.conversationEntityState.entities[action.payload.receiverId];
    if(conversationState)
      conversationEntityState = conversationAdapter.updateOne({
        id : action.payload.receiverId,
        changes :{
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : action.payload.id,
            timeStamp : action.payload.sendDate.getTime()
          },conversationState.dateOfMessageEntityState)
        }
      },state.conversationEntityState)
    else
      conversationEntityState = conversationAdapter.addOne({
        userId : action.payload.receiverId,
        dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
          messageId : action.payload.id,
          timeStamp : action.payload.sendDate.getTime()
        },dateOfMessageStateAdapter.getInitialState())
      },state.conversationEntityState)

    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState : messageEntityState,
      messagePaginationEntityState : messagePaginationEntityState
    }
  }),

  on(markMessageReceivedAsViewedAction,(state,action) => {
    let messageEntityState;
    let messageState = state.messageEntityState.entities[action.payload.id];
    if(messageState){
      if(messageState.status == MessageStatus.Viewed)
        messageEntityState = state.messageEntityState
      else{
        messageEntityState = messageAdapter.updateOne({
          id : action.payload.id,
          changes : {
            viewedDate : messageState.viewedDate ?? action.payload.viewedDate!,
            status : MessageStatus.Viewed
          }
        },state.messageEntityState)
      }
    }
    else{
      messageEntityState = messageAdapter.addOne({
        ...action.payload,
        status : MessageStatus.Viewed,
        timeStamp : action.payload.sendDate.getTime()
      },state.messageEntityState)
    }
    let messagePaginationEntityState = state.messagePaginationEntityState;
    let messagePagination = state.messagePaginationEntityState.entities[action.payload.senderId]
    if(!messagePagination)
      messagePaginationEntityState = messagePaginationAdapter.addOne({
        userId : action.payload.senderId,
        isDescending : true,
        isLast : false,
        take : takeValueOfMessage,
      },messagePaginationEntityState)

    let conversationEntityState;
    let conversationState = state.conversationEntityState.entities[action.payload.senderId];
    if(conversationState)
      conversationEntityState = conversationAdapter.updateOne({
        id : action.payload.senderId,
        changes :{
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : action.payload.id,
            timeStamp : action.payload.sendDate.getTime()
          },conversationState.dateOfMessageEntityState)
        }
      },state.conversationEntityState)
    else
      conversationEntityState = conversationAdapter.addOne({
        userId : action.payload.senderId,
        dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
          messageId : action.payload.id,
          timeStamp : action.payload.sendDate.getTime()
        },dateOfMessageStateAdapter.getInitialState())
      },state.conversationEntityState)

    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState : messageEntityState,
      messagePaginationEntityState : messagePaginationEntityState
    }
  }),

  on(markMessagesSentAsViewedAction,(state,action) => {

    let conversationEntityState = state.conversationEntityState;
    let messageEntityState = state.messageEntityState;
    let messagePaginationEntityState = state.messagePaginationEntityState;
    for(let i = 0; i < action.payload.length;i++){

      let message = action.payload[i];

      let conversationState = conversationEntityState.entities[message.receiverId];
      if(conversationState)
        conversationEntityState = conversationAdapter.updateOne({
          id : message.receiverId,
          changes : {
            dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
              messageId : message.id,timeStamp : message.sendDate.getTime()
            },conversationState.dateOfMessageEntityState)
          }
        },conversationEntityState)
      else
        conversationEntityState = conversationAdapter.addOne({
          userId : message.receiverId,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : message.id,timeStamp : message.sendDate.getTime()
          },dateOfMessageStateAdapter.getInitialState())
        },conversationEntityState)

      let messageState = messageEntityState.entities[message.id];
      if(messageState)
        if(messageState.status == MessageStatus.Viewed)
          messageEntityState = state.messageEntityState
        else
          messageEntityState = messageAdapter.updateOne({
            id : message.id,
            changes : {
              viewedDate : messageState.viewedDate ?? message.viewedDate!,
              status : MessageStatus.Viewed
          }
        },messageEntityState)
      else
        messageEntityState = messageAdapter.addOne({
          ...message,
          timeStamp : message.sendDate.getTime()
        },messageEntityState)

      let messagePagination = state.messagePaginationEntityState.entities[message.receiverId]
      if(!messagePagination)
        messagePaginationEntityState = messagePaginationAdapter.addOne({
          userId : message.receiverId,
          isDescending : true,
          isLast : false,
          take : takeValueOfMessage,
        },messagePaginationEntityState)
    }

    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState : messageEntityState,
      messagePaginationEntityState : messagePaginationEntityState,
    }
  }),

  on(markMessagesReceivedAsViewedAction,(state,action) => {

    let conversationEntityState = state.conversationEntityState;
    let messageEntityState = state.messageEntityState;
    let messagePaginationEntityState = state.messagePaginationEntityState;

    for(let i = 0; i < action.payload.length;i++){

      let message = action.payload[i];

      let conversationState = conversationEntityState.entities[message.senderId];
      if(conversationState)
        conversationEntityState = conversationAdapter.updateOne({
          id : message.senderId,
          changes : {
            dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
              messageId : message.id,timeStamp : message.sendDate.getTime()
            },conversationState.dateOfMessageEntityState)
          }
        },conversationEntityState)
      else
        conversationEntityState = conversationAdapter.addOne({
          userId : message.senderId,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : message.id,timeStamp : message.sendDate.getTime()
          },dateOfMessageStateAdapter.getInitialState())
        },conversationEntityState)

      let messageState = messageEntityState.entities[message.id];
      if(messageState)
        if(messageState.status == MessageStatus.Viewed)
          messageEntityState = state.messageEntityState
        else
          messageEntityState = messageAdapter.updateOne({
            id : message.id,
            changes : {
              viewedDate : messageState.viewedDate ?? message.viewedDate!,
              status : MessageStatus.Viewed
          }
        },messageEntityState)
      else
        messageEntityState = messageAdapter.addOne({
          ...message,
          timeStamp : message.sendDate.getTime()
        },messageEntityState)

      let messagePagination = state.messagePaginationEntityState.entities[message.receiverId]
      if(!messagePagination)
        messagePaginationEntityState = messagePaginationAdapter.addOne({
          userId : message.receiverId,
          isDescending : true,
          isLast : false,
          take : takeValueOfMessage,
        },messagePaginationEntityState)
    }

    return {
      ...state,
      conversationEntityState : conversationEntityState,
      messageEntityState : messageEntityState,
      messagePaginationEntityState : messagePaginationEntityState,
      isSynchronized : true
    }
  })

)

function AddMessages(c : ConversationResponse[],s : EntityState<MessageState>,receivedDate : Date) : EntityState<MessageState>{

  let r : EntityState<MessageState> = s;
  for(let i = 0; i < c.length; i++){
    r = messageAdapter.addMany(
      c[i].messages.map(m => ({
        ...m,
        timeStamp :
          c[i].userId == m.senderId ?
            m.receivedDate ?
              m.receivedDate.getTime() :
              receivedDate.getTime() :
            m.sendDate.getTime()
      })),
      r
    )
  }
  return r;
}
