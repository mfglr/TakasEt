import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { nextPageMessagesAction, nextPageMessagesSuccessAction, noAction, sendMessageAction } from "./actions";
import { filter, first, from, mergeMap, of } from "rxjs";
import { Store } from "@ngrx/store";
import { ChatHubService } from "src/app/services/chat-hub.service";
import { ConversationService } from "../../../services/conversation.service";
import { State } from "./reducer";
import { selectMessages } from "./selectors";

@Injectable()
export class ConversationPageEffect{

  constructor(
    private readonly actions : Actions,
    private readonly chatHub : ChatHubService,
    private readonly conversationService : ConversationService,
    private readonly store : Store<State>
  ) {}

  getMessages$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageMessagesAction),
        mergeMap(
          action => this.store.select(selectMessages({userId : action.userId})).pipe(
            filter(state => state != undefined && !state.isLast),
            first(),
            mergeMap(state => this.conversationService.getMessages({...state!.page,userId : action.userId})),
            mergeMap(response => {
              if(!response.isError)
                return of(nextPageMessagesSuccessAction({userId : action.userId, payload : response.data!}))
              return of()
            })
          )
        ),
      )
    }
  )

  sendMessage$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(sendMessageAction),
        mergeMap((action) => from(this.chatHub.hubConnection!.invoke("SendMessage",action.request))),
        mergeMap(() => of(noAction()))
      )
    }
  )

}
