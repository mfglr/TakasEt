import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import {
  nextPageMessagesSuccessAction, markMessageAsCreatedSuccessAction,
  markMessageAsReceivedAction, markMessageAsReceivedSuccessAction, markMessageAsViewedAction,
  markMessageAsViewedSuccessAction, markMessagesAsViewedAction, markMessagesAsViewedSuccessAction,
  markNewMessagesAsViewedAction, nextPageMessagesAction, loadNewMessagesSuccessAction,
  loadNewMessagesAction, nextPageUsersAction, nextPageUsersSuccessAction, nextPageConversationsAction,
  nextPageConversationsSuccessAction, nextPageUsersFailedAction, nextPageConversationsFailedAction,
  markMessagesAsReceivedSuccessAction, markMessagesAsReceivedFailedAction, markMessagesAsReceivedAction
} from "./actions";
import { filter, first, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { MessageService } from "../services/message.service";
import { UserService } from "src/app/services/user.service";
import { ChatState, ConversationState } from "./reducer";
import { ConversationService } from "../services/conversation-service";
import { selectConversationPagination, selectMessage, selectMessagePagination, selectUserPagination } from "./selectors";
import { LoginState } from "src/app/account/state/reducer";
import { selectUserId } from "src/app/account/state/selectors";
import { ConversationResponse } from "../models/responses/conversation-response";

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

  loadNewMessages$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(loadNewMessagesAction),
        mergeMap(action => this.messageService.getNewMessages({}).pipe(
          mergeMap(response =>{
            if(!response.isError){
              return of(
                loadNewMessagesSuccessAction({payload : response.data!}),
                markMessagesAsReceivedAction({request : {ids : response.data!.map(x => x.id)}})
              )
            }
            return of()
          })
        )),
      )
    }
  )
  nextPageConversations$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageConversationsAction),
        withLatestFrom(
          this.chatStore.select(selectConversationPagination),
          this.loginStore.select(selectUserId)
        ),
        filter(([action,state,loginUserId]) => !state.isLast),
        mergeMap(
          ([action,state,loginUserId]) => this.conversationService.getConversations({...state}).pipe(
            mergeMap(c =>{
              if(!c.isError)
                return this.userService.getUsersByIds({ids : c.data!.map(x => x.userId)}).pipe(
                  mergeMap(u => {
                    if(!u.isError){
                      let r : ConversationResponse[] = [];
                      for(let i = 0; i < c.data!.length; i++)
                        r[i] = {...c.data![i], user : u.data!.find(x => x.id == c.data![i].userId)}
                      return of(nextPageConversationsSuccessAction({payload : r,loginUserId : loginUserId!}))
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
  markMessagesAsReceived$ = createEffect(
    () => this.actions.pipe(
      ofType(markMessagesAsReceivedAction),
      mergeMap(
        action => this.messageService.markMessagesAsReceived(action.request).pipe(
          mergeMap(response => {
            if(!response.isError)
              return of(markMessagesAsReceivedSuccessAction())
            return of(markMessagesAsReceivedFailedAction());
          })
        )
      )
    )
  )

  nextPageUsers = createEffect(
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

  nextPageMessages$ = createEffect(
    () => this.actions.pipe(
      ofType(nextPageMessagesAction),
      withLatestFrom(this.loginStore.select(selectUserId)),
      mergeMap(
        ([action,loginUserId]) => this.chatStore.select(selectMessagePagination({userId : action.userId,})).pipe(
          first(),
          filter(state => !state.isLast),
          mergeMap(state => this.messageService.getMessages({...state,userId : action.userId})),
          mergeMap(response => {
            if(!response.isError)
              return of(nextPageMessagesSuccessAction({
                userId : action.userId,payload : response.data!,loginUserId : loginUserId!
              }))
            return of()
          })
        )
      )
    )
  )

  // markMessageAsReceived$ = createEffect(
  //   () => this.actions.pipe(
  //     ofType(markMessageAsReceivedAction),
  //     mergeMap(
  //       action => this.chatStore.select(selectConversation({receiverId : action.receiverId})).pipe(
  //         filter(state => state != undefined && state.messages.entities[action.messageId] != undefined),
  //         first(),
  //         mergeMap(() => of(markMessageAsReceivedSuccessAction(action)))
  //       )
  //     ),
  //   )
  // )
  // markMessageAsViewed$ = createEffect(
  //   () => this.actions.pipe(
  //     ofType(markMessageAsViewedAction),
  //     mergeMap(
  //       action => this.chatStore.select(selectConversation({receiverId : action.receiverId})).pipe(
  //         filter(state => state != undefined && state.messages.entities[action.messageId] != undefined),
  //         first(),
  //         mergeMap(() => of(markMessageAsViewedSuccessAction(action)))
  //       )
  //     ),
  //   )
  // )

  // markNewMessagesAsViewed$ = createEffect(
  //   () => this.actions.pipe(
  //     ofType(markNewMessagesAsViewedAction),
  //     mergeMap(
  //       action => this.chatStore.select(selectIdsOfUnViewedMessages({userId : action.receiverId})).pipe(
  //         filter(ids => ids.length > 0),
  //         first(),
  //         mergeMap(
  //           ids => this.messageService.markMessagesAsViewed({
  //             userId : action.receiverId,
  //             viewedDate : action.viewedDate
  //           }).pipe(
  //             mergeMap(response =>{
  //               if(!response.isError)
  //                 return of(markMessagesAsViewedAction({
  //                   receiverId : action.receiverId,
  //                   ids : ids,
  //                   viewedDate : action.viewedDate
  //                 }))
  //               return of()
  //             })
  //           )
  //         )
  //       )
  //     )
  //   )
  // )
  // markMessagesAsViewed$ = createEffect(
  //   () => this.actions.pipe(
  //     ofType(markMessagesAsViewedAction),
  //     mergeMap(
  //       action => this.chatStore.select(selectConversation({receiverId : action.receiverId})).pipe(
  //         filter(state => {
  //           if(!state) return false;
  //           for(let i = 0; i < action.ids.length; i++){
  //             if(state.messages.entities[action.ids[i]] == undefined)
  //               return false;
  //           }
  //           return true;
  //         }),
  //         first(),
  //         mergeMap(() => of(markMessagesAsViewedSuccessAction(action)))
  //       )
  //     )
  //   )
  // )


}
