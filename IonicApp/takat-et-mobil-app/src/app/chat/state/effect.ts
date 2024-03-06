import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { nextPageConversationsAction, nextPageMessagesAction, nextPageMessagesSuccessAction, nextPageSuccessConversationAction } from "./actions";
import { filter, first, mergeMap, of, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { Chat } from "./reducer";
import { selectConversation, selectStore } from "./selectors";
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
        mergeMap(([action,state]) => this.conversationService.getConversations({...state.page})),
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


}
