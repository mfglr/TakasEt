import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import {
  nextPageMessagesSuccessAction, markMessageAsCreatedSuccessAction, markMessageAsReceivedSuccessAction,
  markMessageAsViewedAction, markMessageAsViewedSuccessAction,
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
