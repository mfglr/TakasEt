import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { MessageResponse, MessageStatus } from "../models/responses/message-response";
import { createReducer, on } from "@ngrx/store";
import {
  markMessageAsCreatedSuccessAction, markMessageAsReceivedSuccessAction, markMessageAsViewedSuccessAction,
  markMessagesAsViewedSuccessAction, receiveMessageAction, sendMessageSuccessAction,
  nextPageMessagesSuccessAction, nextPageConversationsSuccessAction, connectionFailedAction,
  connectionSuccessAction, nextPageUsersSuccessAction, loadNewMessagesSuccessAction,
} from "./actions";
import { MessageImageResponse } from "../models/responses/message-image-response";
import { UserImageResponse } from "src/app/models/responses/user-image-response";
import { takevalueOfMessage } from "src/app/state/app-entity-state/app-entity-state";

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
  dateOfMessageEntityState : EntityState<DateOfMessageState>
}
export const conversationAdapter = createEntityAdapter<ConversationState>({
  selectId : state => state.userId,
  sortComparer : (x,y) =>{
    let xdates = selectDateOfMessageStates(x.dateOfMessageEntityState)
    let xdate = xdates.length > 0 ? xdates[0].timeStamp : new Date(1900).getTime();

    let ydates = selectDateOfMessageStates(y.dateOfMessageEntityState)
    let ydate = ydates.length > 0 ? xdates[0].timeStamp : new Date(1900).getTime();

    return xdate > ydate ? 1 : -1
  }
})
export const selectConversationStates = conversationAdapter.getSelectors().selectAll


export interface ChatState{
  synchronized : boolean;
  isConnected : boolean;
  userEntityState : EntityState<UserState>;
  messageEntityState : EntityState<MessageState>;
  conversationEntityState : EntityState<ConversationState>;
  userPagination : Pagination;
  conversationPagination : Pagination;
  messagePaginationEntityState : EntityState<MessagePagination>;
}

const initialState : ChatState = {
  synchronized : false,
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
  on( connectionFailedAction, state => ({...state,isConnected : false}) ),
  on( connectionSuccessAction, state => ({...state,isConnected : true}) ),

  on(
    loadNewMessagesSuccessAction,
    (state,action) => ({
      ...state,

      synchronized : true,

      conversationEntityState : conversationAdapter.setMany(
        action.payload.map((mu) : ConversationState => {
          let dateOfMessageState = {
            messageId : mu.message.id,
            timeStamp : mu.message.receivedDate!.getTime()
          }
          let conversationState = state.conversationEntityState.entities[mu.message.senderId];
          if(conversationState)
            return {
              ...conversationState,
              dateOfMessageEntityState : dateOfMessageStateAdapter.addOne(
                dateOfMessageState,conversationState.dateOfMessageEntityState
              )
            }
          return {
            userId : mu.message.senderId,
            userState : mu.user ? {...mu.user} : undefined,
            dateOfMessageEntityState : dateOfMessageStateAdapter.addOne(
              dateOfMessageState,dateOfMessageStateAdapter.getInitialState()
            )
          }
        }),
        state.conversationEntityState
      ),

      messageEntityState : messageAdapter.addMany(action.payload.map((mu) : MessageState => ({
        ...mu.message,timeStamp : mu.message.receivedDate!.getTime(),
      })),state.messageEntityState),

      messagePaginationEntityState : messagePaginationAdapter.addMany(
        action.payload.map((m) : MessagePagination => ({
          userId : m.message.senderId,
          isDescending : true,
          isLast : false,
          take : takeValueOfMessage,
        })),
        state.messagePaginationEntityState
      )

    })
  ),


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
        take : takevalueOfMessage,
      })),
      state.messagePaginationEntityState
    )
  })),


  on(
    nextPageConversationsSuccessAction,
    (state,action) => ({
      ...state,
      conversationEntityState : conversationAdapter.setMany(
        action.payload.map((x) : ConversationState =>{

          var conversationState = state.conversationEntityState.entities[x.userId]

          if(conversationState)
            return {
              userId : x.userId,
              dateOfMessageEntityState : dateOfMessageStateAdapter.addMany(
                x.messages.map(m => {
                  let timeStamp =
                    action.loginUserId == m.senderId ?
                      m.sendDate :
                      m.receivedDate ? m.receivedDate : new Date()
                  return {
                    messageId : m.id,
                    timeStamp : timeStamp.getTime()
                  }
                }),
                conversationState.dateOfMessageEntityState
              )
            }

          return {
            userId : x.userId,
            userState : x.user ? {...x.user} : undefined,
            dateOfMessageEntityState : dateOfMessageStateAdapter.addMany(
              x.messages.map(m => {
                let timeStamp =
                  action.loginUserId == m.senderId ?
                    m.sendDate :
                    m.receivedDate ? m.receivedDate : new Date()
                return {
                  messageId : m.id,
                  timeStamp : timeStamp.getTime()
                }
              }),
              dateOfMessageStateAdapter.getInitialState()
            )
          }

        }),
        state.conversationEntityState
      ),

      messageEntityState : action.payload.length > 0 ? messageAdapter.addMany(
        action.payload.map(x => x.messages).reduce((prev,curr) => prev.concat(curr)).map((x) : MessageState =>{
          let receivedDate = x.receivedDate ? x.receivedDate : new Date();
          return {
            ...x,
            timeStamp : action.loginUserId == x.senderId ? x.sendDate.getTime() : receivedDate.getTime(),
            receivedDate : receivedDate
          }
        }),
        state.messageEntityState
      ) : state.messageEntityState,

      messagePaginationEntityState : messagePaginationAdapter.setMany(
        action.payload.map((m) : MessagePagination => ({
          userId : m.userId,
          isDescending : true,
          take : takevalueOfMessage,
          isLast : m.messages.length < takeValueOfMessage,
        })),
        state.messagePaginationEntityState
      )
    })
  ),
  on(
    nextPageMessagesSuccessAction,
    (state,action) => ({
      ...state,

      conversationEntityState : conversationAdapter.updateOne({
        id : action.userId,
        changes : {
          ...state.conversationEntityState.entities[action.userId]!,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addMany(
            action.payload.map(x => ({
              messageId : x.id,
              timeStamp : x.senderId == action.userId ? x.receivedDate!.getTime() : x.sendDate.getTime()
            })),
            state.conversationEntityState.entities[action.userId]!.dateOfMessageEntityState)
        }
      },state.conversationEntityState),

      messageEntityState : messageAdapter.addMany(
        action.payload.map((x) : MessageState => ({
          ...x,
          timeStamp :
            action.loginUserId == x.senderId ?
              new Date(x.sendDate).getTime() :
              x.receivedDate ?
                new Date(x.receivedDate).getTime() :
                new Date().getTime(),
        })),
        state.messageEntityState
      ),

      messagePaginationEntityState : messagePaginationAdapter.setOne({
        userId : action.userId,
        isDescending : true,
        take : takeValueOfMessage,
        isLast : action.payload.length < takeValueOfMessage,
      },state.messagePaginationEntityState)

    })
  ),
  on(
    sendMessageSuccessAction,
    (state,action) => {
      var messageEntityState = messageAdapter.addOne({
        timeStamp : action.request.sendDate,
        sendDate : new Date(action.request.sendDate),
        content : action.request.content,
        status : MessageStatus.NotCreated,
        id : action.request.id,
        receiverId : action.request.receiverId,
        senderId : action.request.senderId,
      },state.messageEntityState)

      let messagePaginationEntityState = state.messagePaginationEntityState
      if(!messagePaginationEntityState.entities[action.request.receiverId])
        messagePaginationEntityState = messagePaginationAdapter.addOne({
          userId : action.request.receiverId,
          isDescending : true,
          isLast : false,
          take : takeValueOfMessage,
        },messagePaginationEntityState)

      let conversationEntityState;
      let sendDate = new Date(action.request.sendDate)
      let conversationState = state.conversationEntityState.entities[action.request.receiverId]
      if(conversationState)
        conversationEntityState = conversationAdapter.addOne({
          ...conversationState,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : action.request.id,
            timeStamp : action.request.sendDate
          },conversationState.dateOfMessageEntityState)
        },state.conversationEntityState)
      else
        conversationEntityState = conversationAdapter.addOne({
          userId : action.request.receiverId,
          dateOfMessageEntityState : dateOfMessageStateAdapter.addOne({
            messageId : action.request.id,
            timeStamp : action.request.sendDate
          },dateOfMessageStateAdapter.getInitialState())
        },state.conversationEntityState)


      return {
        ...state,
        messageEntityState : messageEntityState,
        conversationEntityState : conversationEntityState,
        messagePaginationEntityState : messagePaginationEntityState,
      };

    }
  ),
  // on(
  //   markMessageAsCreatedSuccessAction,
  //   (state,action) => {

  //     let messageEntityState;
  //     let messageState = state.messageEntityState.entities[action.message.id];
  //     if(messageState)
  //       messageEntityState = messageAdapter.updateOne({
  //         id : action.message.id,
  //         changes : {
  //           ...messageState,
  //           sendDate : action.message.sendDate,
  //           createdDate : action.message.createdDate,
  //           receivedDate : action.message.receivedDate,
  //           viewedDate : action.message.viewedDate,
  //           status : action.message.status
  //         }
  //       },state.messageEntityState)
  //     else
  //       messageEntityState = messageAdapter.addOne({
  //         ...action.message,
  //         timeStamp : action.message.sendDate.getTime()
  //       },state.messageEntityState)

  //     let messagePaginationEntityState = state.messagePaginationEntityState;
  //     let messagePagination = state.messagePaginationEntityState.entities[action.message.receiverId]
  //     if(!messagePagination)
  //       messagePaginationEntityState = messagePaginationAdapter.addOne({
  //         userId : action.message.receiverId,
  //         isDescending : true,
  //         isLast : false,
  //         take : takeValueOfMessage,
  //       },messagePaginationEntityState)

  //     let conversationEntityState;
  //     let conversationState = state.conversationEntityState.entities[action.message.receiverId];
  //     if(conversationState)
  //       conversationEntityState = conversationAdapter.updateOne({
  //         id : action.message.id,
  //         changes : {
  //           dateOfLastMessage :
  //             action.message.sendDate > conversationState.dateOfLastMessage ?
  //               action.message.sendDate :
  //               conversationState.dateOfLastMessage
  //         }
  //       },state.conversationEntityState)
  //     else
  //       conversationEntityState = conversationAdapter.addOne({
  //         userId : action.message.receiverId,
  //         dateOfLastMessage : action.message.sendDate
  //       },state.conversationEntityState)

  //     return {
  //       ...state,
  //       conversationEntityState : conversationEntityState,
  //       messageEntityState : messageEntityState,
  //       messagePaginationEntityState : messagePaginationEntityState
  //     }
  //   }
  // ),
  // on(
  //   receiveMessageAction,
  //   (state,action) => {
  //     if(state.conversations.entities[action.payload.senderId])
  //       return {
  //         ...state,
  //         conversations : conversationAdapter.updateOne({
  //           id : action.payload.senderId,
  //           changes : {
  //             messages : messageAdapter.addOne(
  //               action.payload,
  //               state.conversations.entities[action.payload.senderId]!.messages
  //             )
  //           }
  //         },state.conversations)
  //       }
  //     var date = new Date();
  //     return {
  //       ...state,
  //       conversations : conversationAdapter.addOne({
  //           receiverId : action.payload.senderId,
  //         },
  //         isLast : false,
  //         messages : messageAdapter.addOne(action.payload,messageAdapter.getInitialState()),
  //         page : {isDescending : true,lastValue : action.payload.sendDate.getTime(),take : takeValueOfMessage}
  //       },state.conversations)
  //     }
  //   }
  // ),        conversation : {
  //           id : "",
  //           createdDate : date,
  //           dateTimeOfLastMessage : date,
  //           newMessages : [],
  //

  // on(
  //   markMessageAsReceivedSuccessAction,
  //   (state,action) => {
  //     var message = state.conversations.entities[action.receiverId]!.messages.entities[action.messageId]!

  //     if(message.status == MessageStatus.Received)
  //       return state;

  //     var newState = MessageStatus.Received;
  //     if(message.status == MessageStatus.Viewed)
  //       newState = MessageStatus.Viewed;

  //     return ({
  //       ...state,
  //       conversations : conversationAdapter.updateOne({
  //         id : action.receiverId,
  //         changes : {
  //           messages : messageAdapter.updateOne({
  //             id : action.messageId, changes : { status : newState,receivedDate : action.receivedDate }
  //           },state.conversations.entities[action.receiverId]!.messages)
  //         }
  //       },state.conversations)
  //     })
  //   }
  // ),

  // on(
  //   markMessagesAsViewedSuccessAction,
  //   (state,action) => ({
  //     ...state,
  //     conversations : conversationAdapter.updateOne({
  //       id : action.receiverId,
  //       changes : {
  //         messages : messageAdapter.updateMany(
  //           action.ids.map((x) : Update<MessageResponse> => ({
  //             id : x, changes : {status : MessageStatus.Viewed,viewedDate : action.viewedDate}
  //           })),
  //           state.conversations.entities[action.receiverId]!.messages)
  //       }
  //     },state.conversations)
  //   })
  // ),
  // on(
  //   markMessageAsViewedSuccessAction,
  //   (state,action) => {
  //     var message = state.conversations.entities[action.receiverId]!.messages.entities[action.messageId]!
  //     if(message.status == MessageStatus.Viewed)
  //       return state;
  //     return ({
  //       ...state,
  //       conversations : conversationAdapter.updateOne({
  //         id : action.receiverId,
  //         changes : {
  //           messages : messageAdapter.updateOne({
  //             id : action.messageId, changes : { status : MessageStatus.Viewed,viewedDate : action.viewedDate }
  //           },state.conversations.entities[action.receiverId]!.messages)
  //         }
  //       },state.conversations)
  //     })
  //   }
  // ),

)


