import { Injectable } from "@angular/core";
import { ConversationService } from "../../../services/conversation.service";
import { ChatHomePageState } from "./reducer";
import { Store } from "@ngrx/store";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { nextPageConversationsAction, nextPageConversationsSuccessAction } from "./actions";
import { filter, mergeMap, of, withLatestFrom } from "rxjs";
import { selectConversations } from "./selectors";

@Injectable()
export class ChatHomePageEffect{
  constructor(
    private readonly actions : Actions,
    private readonly conversationService : ConversationService,
    private readonly chatHomePageStore : Store<ChatHomePageState>
  ) {}

  getNextPageConversations$ = createEffect(
    () => {
      return this.actions.pipe(
        ofType(nextPageConversationsAction),
        withLatestFrom(this.chatHomePageStore.select(selectConversations)),
        filter(([action,state]) => !state.isLast),
        mergeMap( ([action,state]) => this.conversationService.getConversations({...state.page}) ),
        mergeMap(
          conversations => {
            if(!conversations.isError)
              return of(nextPageConversationsSuccessAction({payload : conversations.data!}))
            return of()
          }
        )
      )
    }
  )

}
