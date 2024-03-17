import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import {
  nextPageMessagesSuccessAction, markMessageAsCreatedSuccessAction, markMessageAsReceivedSuccessAction,
  markMessageAsViewedAction, markMessageAsViewedSuccessAction, markMessagesAsViewedAction,
  markMessagesAsViewedSuccessAction, nextPageMessagesAction,
  loadNewMessagesSuccessAction, loadNewMessagesAction, nextPageUsersAction, nextPageUsersSuccessAction,
  nextPageConversationsAction, nextPageConversationsSuccessAction, nextPageUsersFailedAction,
  nextPageConversationsFailedAction, markMessagesAsReceivedSuccessAction, markMessagesAsReceivedFailedAction,
  markMessagesAsReceivedAction,
  connectionSuccessAction,
  loadConversationUserAction,
  loadConversationUserSuccessAction,
  synchronizedSuccessAction,
  synchronizedFailedAction,
} from "./actions";
import { filter, first, from, merge, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { MessageService } from "../services/message.service";
import { UserService } from "src/app/services/user.service";
import { ChatState, selectConversationStates } from "./reducer";
import { ConversationService } from "../services/conversation-service";
import { selectConversationPagination, selectConversationState, selectIsSynchronized, selectMessagePagination, selectUserPagination } from "./selectors";
import { LoginState } from "src/app/account/state/reducer";
import { ConversationResponse } from "../models/responses/conversation-response";
import { MessageResponse, MessageStatus } from "../models/responses/message-response";
import { UserResponse } from "src/app/models/responses/user-response";

@Injectable()
export class ChatEffect{

  constructor(
    private readonly actions : Actions,
    private readonly loginStore : Store<LoginState>,
    private readonly chatStore : Store<ChatState>,
    private readonly messageService : MessageService,
    private readonly userService : UserService,
    private readonly conversationService : ConversationService,
  ) {}

  private getMessageNotReceived(messages : MessageResponse[]){
    return messages.filter(x => x.status != MessageStatus.Received).map(x => x.id);
  }

  private combineMessagesAndUsers(messages : MessageResponse[],users : UserResponse[]) :
  {message : MessageResponse,user? : UserResponse}[]{
    let r : {message : MessageResponse,user? : UserResponse}[] = [];
    for(let i = 0; i < messages.length;i++)
      r[i] = {message : messages[i], user : users.find(x => x.id == messages[i].senderId)}
    return r;
  }

  nextPageUsers$ = createEffect(
    () => this.actions.pipe(
      ofType(nextPageUsersAction),
      withLatestFrom(this.chatStore.select(selectUserPagination)),
      filter(([action,state]) => !state.isLast),
      mergeMap(([action,state]) => this.userService.getFollowersOrFollowings({...state})),
      mergeMap(response => {
        if(!response.isError)
          return of(nextPageUsersSuccessAction({payload : response.data!}))
        return of(nextPageUsersFailedAction({payload : response}))
      })
    )
  )

  loadConversationUser$ = createEffect(
    () => this.actions.pipe(
      ofType(loadConversationUserAction),
      mergeMap(action => this.userService.getUserById({userId : action.userId})),
      mergeMap(response => {
        if(!response.isError)
          return of(loadConversationUserSuccessAction({payload : response.data!}))
        return of()
      })
    )
  )

  connectionSuccess$ = createEffect(
    () => this.actions.pipe(
      ofType(connectionSuccessAction),
      mergeMap(() => of(loadNewMessagesAction()))
    )
  )

  loadNewMessages$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(loadNewMessagesAction),
        mergeMap((action) => this.messageService.getNewMessages({}).pipe(
          mergeMap(messages =>{
            if(!messages.isError){
              return this.userService.getUsersByIds({ids : Array.from(new Set(messages.data!.map(x => x.senderId)))}).pipe(
                mergeMap(users => {
                  if(!users.isError){
                    var date = new Date();
                    return of(
                      loadNewMessagesSuccessAction({
                        payload : this.combineMessagesAndUsers(messages.data!,users.data!),
                        receivedDate : date
                      }),
                      markMessagesAsReceivedAction({
                        request : {
                          ids : this.getMessageNotReceived(messages.data!),
                          receivedDate : date.getTime()
                        }
                      })
                    )
                  }
                  return of()
                })
              )
            }
            return of()
          }))
        ),
      )
    }
  )

  markMessagesAsReceived$ = createEffect(
    () => this.actions.pipe(
      ofType(markMessagesAsReceivedAction),
      mergeMap(
        action => this.messageService.markMessagesAsReceived(action.request).pipe(
          mergeMap(response => {
            if(!response.isError)
              return of(synchronizedSuccessAction())
            return of(synchronizedFailedAction());
          })
        )
      )
    )
  )

  nextPageConversations$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageConversationsAction),
        mergeMap(() => this.chatStore.select(selectIsSynchronized).pipe(
          filter(isSynchronized => isSynchronized),
          first()
        )),
        withLatestFrom(this.chatStore.select(selectConversationPagination)),
        filter(([isSynchronized,state]) => !state.isLast),
        mergeMap(
          ([isSynchronized,state]) => this.conversationService.getConversations({...state}).pipe(
            mergeMap(c =>{
              if(!c.isError)
                return this.userService.getUsersByIds({ids : c.data!.map(x => x.userId)}).pipe(
                  mergeMap(u => {
                    if(!u.isError){
                      let r : ConversationResponse[] = [];
                      for(let i = 0; i < c.data!.length; i++)
                        r[i] = {...c.data![i], user : u.data!.find(x => x.id == c.data![i].userId)}
                      return of(nextPageConversationsSuccessAction({payload : r,receivedDate : new Date()}))
                    }
                    return of(nextPageConversationsFailedAction({payload : u}))
                  })
                )
              return of(nextPageConversationsFailedAction({payload : c}))
            })
          )
        ),

      )
    }
  )

  nextPageMessages$ = createEffect(
    () => this.actions.pipe(
      ofType(nextPageMessagesAction),
      mergeMap(
        (action) => this.chatStore.select(selectMessagePagination({userId : action.user.id})).pipe(
          first(),
          filter(state => !state.isLast),
          mergeMap(state => this.messageService.getMessages({...state,userId : action.user.id})),
          mergeMap(response => {
            if(!response.isError)
              return of(nextPageMessagesSuccessAction({user : action.user,payload : response.data!}))
            return of()
          })
        )
      )
    )
  )

}
