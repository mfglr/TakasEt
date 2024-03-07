import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { markMessageAsCreatedAction, markMessageAsCreatedSuccessAction, markMessageAsReceivedAction, markMessageAsReceivedSuccessAction, markMessageAsViewedAction, markMessageAsViewedSuccessAction, markMessagesAsViewedAction, markMessagesAsViewedSuccessAction, markNewMessagesAsViewedAction, nextPageConversationsAction, nextPageMessagesAction, nextPageMessagesSuccessAction, nextPageSuccessConversationAction } from "./actions";
import { filter, first, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { Chat } from "./reducer";
import { selectConversation, selectIdsOfUnViewedMessages, selectStore } from "./selectors";
import { ConversationService } from "../services/conversation.service";

@Injectable()
export class ChatEffect{

  constructor(
    private readonly actions : Actions,
    private readonly chatStore : Store<Chat>,
    private readonly conversationService : ConversationService
  ) {}

  nextPageConversations$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageConversationsAction),
        withLatestFrom(this.chatStore.select(selectStore)),
        filter(([action,state]) => !state.isLast),
        mergeMap(([action,state]) => this.conversationService.GetConversationsThatHaveNewMessages({})),
        mergeMap(response =>{
          if(!response.isError)
            return of(nextPageSuccessConversationAction({payload : response.data!}))
          return of()
        })
      )
    }
  )

  nextPageMessages$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageMessagesAction),
        mergeMap(
          action => this.chatStore.select(selectConversation({receiverId : action.receiverId})).pipe(
            filter(state => state != undefined),
            first(),
            filter(state => !(state!.isLast)),
            mergeMap(state => this.conversationService.getMessages({...state!.page,receiverId : action.receiverId})),
            mergeMap(response => {
              if(!response.isError)
                return of(nextPageMessagesSuccessAction({receiverId : action.receiverId,payload : response.data!}))
              return of()
            })
          )
        )
      )
    }
  )

  markMessageAsCreated$ = createEffect(
    () => this.actions.pipe(
      ofType(markMessageAsCreatedAction),
      mergeMap(
        action => this.chatStore.select(selectConversation({receiverId : action.receiverId})).pipe(
          filter(state => state != undefined && state.messages.entities[action.messageId] != undefined),
          first(),
          mergeMap(() => of(markMessageAsCreatedSuccessAction(action)))
        )
      ),
    )
  )

  markMessageAsReceived$ = createEffect(
    () => this.actions.pipe(
      ofType(markMessageAsReceivedAction),
      mergeMap(
        action => this.chatStore.select(selectConversation({receiverId : action.receiverId})).pipe(
          filter(state => state != undefined && state.messages.entities[action.messageId] != undefined),
          first(),
          mergeMap(() => of(markMessageAsReceivedSuccessAction(action)))
        )
      ),
    )
  )

  markMessageAsViewed$ = createEffect(
    () => this.actions.pipe(
      ofType(markMessageAsViewedAction),
      mergeMap(
        action => this.chatStore.select(selectConversation({receiverId : action.receiverId})).pipe(
          filter(state => state != undefined && state.messages.entities[action.messageId] != undefined),
          first(),
          mergeMap(() => of(markMessageAsViewedSuccessAction(action)))
        )
      ),
    )
  )

  markMessagesAsViewed$ = createEffect(
    () => this.actions.pipe(
      ofType(markMessagesAsViewedAction),
      mergeMap(
        action => this.chatStore.select(selectConversation({receiverId : action.receiverId})).pipe(
          filter(state => {
            if(!state) return false;
            for(let i = 0; i < action.ids.length; i++){
              if(state.messages.entities[action.ids[i]] == undefined)
                return false;
            }
            return true;
          }),
          first(),
          mergeMap(() => of(markMessagesAsViewedSuccessAction(action)))
        )
      )
    )
  )

  markNewMessagesAsViewed$ = createEffect(
    () => this.actions.pipe(
      ofType(markNewMessagesAsViewedAction),
      mergeMap(
        action => this.chatStore.select(selectIdsOfUnViewedMessages({receiverId : action.receiverId})).pipe(
          filter(ids => ids.length > 0),
          first(),
          mergeMap(
            ids => this.conversationService.markMessagesAsViewed({
              userId : action.receiverId,
              viewedDate : action.viewedDate
            }).pipe(
              mergeMap(response =>{
                if(!response.isError)
                  return of(markMessagesAsViewedAction({
                    receiverId : action.receiverId,
                    ids : ids,
                    viewedDate : action.viewedDate
                  }))
                return of()
              })
            )
          )
        )
      )
    )
  )

  markNewMessagesAsReceieved = createEffect(
    () => this.actions.pipe(
      ofType(markNewMessagesAsViewedAction),
      mergeMap(
        action => this.chatStore.select(selectIdsOfUnViewedMessages({receiverId : action.receiverId})).pipe(
          filter(ids => ids.length > 0),
          first(),
          mergeMap(
            ids => this.conversationService.markMessagesAsViewed({
              userId : action.receiverId,
              viewedDate : action.viewedDate
            }).pipe(
              mergeMap(response =>{
                if(!response.isError)
                  return of(markMessagesAsViewedAction({
                    receiverId : action.receiverId,
                    ids : ids,
                    viewedDate : action.viewedDate
                  }))
                return of()
              })
            )
          )
        )
      )
    )
  )

}
