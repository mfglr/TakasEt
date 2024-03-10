import { EntityState, Update, createEntityAdapter } from "@ngrx/entity";
import { MessageResponse, MessageStatus } from "../models/responses/message-response";
import { ConversationResponse } from "../models/responses/conversation-response";
import { createReducer, on } from "@ngrx/store";
import {
  markMessageAsCreatedSuccessAction, markMessageAsReceivedSuccessAction, markMessageAsViewedSuccessAction,
  markMessagesAsViewedSuccessAction, receiveMessageAction, sendMessageSuccessAction,
  nextPageMessagesSuccessAction, nextPageConversationsSuccessAction, connectionFailedAction,
  connectionSuccessAction, nextPageUsersSuccessAction, loadNewMessagesSuccessAction,
} from "./actions";
import { UserResponse } from "src/app/models/responses/user-response";
import { MessageImageResponse } from "../models/responses/message-image-response";
import { UserImageResponse } from "src/app/models/responses/user-image-response";

export const takeValueOfMessage = 50;
export const takeValueOfConversation = 20;
export const takeValueOfUser = 20;

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
interface UserEntityState{
  isLast : boolean;
  take : number;
  isDescending : boolean;
  users : EntityState<UserState>
}
export const userAdapter = createEntityAdapter<UserState>({
  selectId : state => state.id,
  sortComparer : (x,y) => x.userName.localeCompare(y.userName)
})


export interface MessageState{
  dateToDisplay : Date;
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
interface MessageEntityState{
  isLast : boolean;
  isDescending : boolean;
  take : number;
  messageStates : EntityState<MessageState>;
}
export const messageAdapter = createEntityAdapter<MessageState>({
  selectId : state => state.id,
  sortComparer : (x,y) => x.dateToDisplay < y.dateToDisplay ? 1 : -1
})

export interface ConversationState{
  userId : string;
  user? : UserResponse;
  messageEntityState : MessageEntityState;
}
interface ConversationEntityState{
  isLast : boolean;
  take : number;
  isDescending : boolean;
  conversationStates : EntityState<ConversationState>
}
export const selectAllMessageStates = messageAdapter.getSelectors().selectAll;
export const sortcomparer = (x : ConversationState,y : ConversationState) => {
  var xr = selectAllMessageStates(x.messageEntityState.messageStates);
  var yr = selectAllMessageStates(y.messageEntityState.messageStates);

  var xlast = xr.length > 0 ? xr[0].dateToDisplay : new Date(1900)
  var ylast = yr.length > 0 ? yr[0].dateToDisplay : new Date(1900)

  return xlast > ylast ? 1 : -1;
}
export const conversationAdapter = createEntityAdapter<ConversationState>({
  selectId : state => state.userId,
  sortComparer : (x,y) => sortcomparer(x,y)
})

export interface ChatState{
  isConnected : boolean;
  conversationEntityState : ConversationEntityState;
  userEntityState : UserEntityState;
}

const initialState : ChatState = {
  isConnected : false,

  userEntityState : {
    isLast : false,
    isDescending : false,
    take : takeValueOfUser,
    users : userAdapter.getInitialState()
  },

  conversationEntityState : {
    isLast : false,
    isDescending : true,
    take : takeValueOfConversation,
    conversationStates : conversationAdapter.getInitialState()
  }
}

export const chatReducer = createReducer(
  initialState,
  on( connectionFailedAction, state => ({...state,isConnected : false}) ),
  on( connectionSuccessAction, state => ({...state,isConnected : true}) ),

  on(
    nextPageUsersSuccessAction,
    (state,action) => ({
      ...state,
      userEntityState : {
        ...state.userEntityState,
        isLast : action.payload.length < takeValueOfUser,
        users : userAdapter.addMany(
          action.payload.map((user) : UserState => ({
            countOfFollowers : user.countOfFollowers,
            countOfFollowings : user.countOfFollowings,
            countOfPosts : user.countOfPosts,
            email : user.email,
            id : user.id,
            images : user.images,
            isFollower : user.isFollower,
            isFollowing : user.isFollowing,
            userName : user.userName,
            createdDate : user.createdDate,
            fullName : user.fullName,
            lastName : user.lastName,
            name : user.name,
            updatedDate : user.updateDate
          })),
          state.userEntityState.users
        ),
      }
    })
  ),

  on(
    loadNewMessagesSuccessAction,
    (state,action) => ({
      ...state,
      conversationEntityState : {
        ...state.conversationEntityState,
        conversations : conversationAdapter.setMany(
          action.payload.map((c) : ConversationState => {

            var conversationState = state.conversationEntityState.conversationStates.entities[c.userId];
            let messageState;
            if(conversationState)
              messageState = conversationState.messageEntityState.messageStates;
            else
              messageState = messageAdapter.getInitialState();

            return {
              userId : c.userId,
              user : c.user,
              messageEntityState : {
                isLast : false,
                isDescending : true,
                take : takeValueOfMessage,
                messageStates : messageAdapter.addMany(c.messages.map((m) : MessageState => ({
                  id : m.id,
                  receiverId : m.receiverId,
                  senderId : m.senderId,
                  content : m.content,
                  dateToDisplay : m.sendDate,
                  status : MessageStatus.Received,
                  images : m.images,
                  sendDate : m.sendDate,
                  createdDate : m.createdDate,
                  receivedDate : action.receivedDate
                })),messageState)
              }
            }

          }
        ),state.conversationEntityState.conversationStates)
      }
    })
  ),

  on(
    nextPageConversationsSuccessAction,
    (state,action) => ({
      ...state,
      conversations : conversationAdapter.setMany(action.payload.map((c) : ConversationState => {
        var conversationState = state.conversationEntityState.conversationStates.entities[c.userId];
        let messageState;
        if(conversationState)
          messageState = conversationState.messageEntityState.messageStates;
        else
          messageState = messageAdapter.getInitialState();

        return {
          userId : c.userId,
          user : c.user,
          messageEntityState : {
            isLast : false,
            isDescending : true,
            take : takeValueOfMessage,
            messageStates : messageAdapter.addMany(c.messages.map((m) : MessageState => ({
              id : m.id,
              receiverId : m.receiverId,
              senderId : m.senderId,
              content : m.content,
              dateToDisplay : m.sendDate,
              status : m.status,
              images : m.images,
              sendDate : m.sendDate,
              createdDate : m.createdDate,
              receivedDate : m.receivedDate,
              viewedDate : m.viewedDate
            })),messageState)
          }
        }
      }),state.conversationEntityState.conversationStates)
    })
  ),

  // on(
  //   nextPageMessagesSuccessAction,
  //   (state,action) => ({
  //     ...state,
  //     conversations : conversationAdapter.updateOne({
  //       id : action.receiverId,
  //       changes : {
  //         messages : messageAdapter.addMany(
  //           action.payload,
  //           state.conversations.entities[action.receiverId]!.messages
  //         ),
  //         isLast : action.payload.length < takeValueOfMessage,
  //         page : {
  //           isDescending : true,
  //           lastValue :
  //             action.payload.length > 0 ?
  //             action.payload[action.payload.length - 1].sendDate.getTime() :
  //             state.page.lastValue,
  //           take : takeValueOfMessage
  //         }
  //       }
  //     },state.conversations)
  //   })
  // ),
  // on(
  //   sendMessageSuccessAction,
  //   (state,action) => ({
  //     ...state,
  //     conversations : conversationAdapter.updateOne({
  //       id : action.request.receiverId,
  //       changes : {
  //         messages : messageAdapter.addOne({
  //           id : action.request.id,
  //           createdDate : new Date(),
  //           receiverId : action.request.receiverId,
  //           senderId : action.request.senderId,
  //           sendDate : new Date(action.request.sendDate),
  //           content : action.request.content,
  //           status : MessageStatus.NotCreated,
  //         },state.conversations.entities[action.request.receiverId]!.messages)
  //       }
  //     },state.conversations)
  //   })
  // ),
  // on(
  //   markMessageAsCreatedSuccessAction,
  //   (state,action) => {
  //     var message = state.conversations.entities[action.receiverId]!.messages.entities[action.messageId]!
  //     if(message.status == MessageStatus.Created)
  //       return state;

  //     var newState = MessageStatus.Created;
  //     if(message.status == MessageStatus.Received)
  //       newState = MessageStatus.Received;

  //     if(message.status == MessageStatus.Viewed)
  //       newState = MessageStatus.Viewed;

  //     return ({
  //       ...state,
  //       conversations : conversationAdapter.updateOne({
  //         id : action.receiverId,
  //         changes : {
  //           messages : messageAdapter.updateOne(
  //             { id : action.messageId, changes : { status : newState }},
  //             state.conversations.entities[action.receiverId]!.messages
  //           )
  //         }
  //       },state.conversations)
  //     })
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
  //         conversation : {
  //           id : "",
  //           createdDate : date,
  //           dateTimeOfLastMessage : date,
  //           newMessages : [],
  //           receiverId : action.payload.senderId,
  //         },
  //         isLast : false,
  //         messages : messageAdapter.addOne(action.payload,messageAdapter.getInitialState()),
  //         page : {isDescending : true,lastValue : action.payload.sendDate.getTime(),take : takeValueOfMessage}
  //       },state.conversations)
  //     }
  //   }
  // ),

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
