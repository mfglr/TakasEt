import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription, first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ChatState, MessageState, UserState, takeValueOfMessage } from '../../state/reducer';
import { markMessageAsViewedSuccessAction, nextPageMessagesAction } from '../../state/actions';
import { selectMessageStatesOfConversatinPage, selectUnviewedMessages } from '../../state/selectors';
import { Router } from '@angular/router';
import { mapDateTimesOfMessageResponse } from 'src/app/helpers/mapping-datetime';
import { MessageResponse } from '../../models/responses/message-response';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit,OnDestroy {

  userState : UserState | null = null;
  receivedMessagesSubscription? : Subscription;
  messages$? : Observable<MessageState[]>

  constructor(
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<ChatState>,
    private readonly router : Router
  ) {
    var state = this.router.getCurrentNavigation()?.extras.state;
    if(state)
      this.userState = state as (UserState | null)
  }

  ngOnInit() {

    if(this.userState){
      this.messages$ = this.chatStore.select(selectMessageStatesOfConversatinPage({userId : this.userState.id}));

      this.messages$.pipe(first()).subscribe(
        x => {
          if(x.length < takeValueOfMessage)
            this.chatStore.dispatch(nextPageMessagesAction({user : this.userState!}))
        }
      )

      this.chatStore.select(selectUnviewedMessages({userId : this.userState.id})).pipe(first()).subscribe(
        messages => {
          if(messages.length > 0){
            // this.chatStore.dispatch(markMessageAsViewedSuccessAction({payload : }))
          }
        }
      )

      this.receivedMessagesSubscription = this.chatHub.receivedMessages.subscribe(message => {
        var viewedDate = new Date();
        var message : MessageResponse = {...mapDateTimesOfMessageResponse(message),viewedDate : viewedDate};
        this.chatStore.dispatch(markMessageAsViewedSuccessAction({payload : message}))

        this.chatHub.hubConnection!.invoke(
          "SendMessageViewedNotification",
          {messageId : message.id,viewedDate : viewedDate}
        )
      })

      // this.chatStore.dispatch(markNewMessagesAsViewedAction({
      //   receiverId : this.userState!.id,
      //   viewedDate : new Date()
      // }));

    }
  }

  ngOnDestroy(){
    this.receivedMessagesSubscription?.unsubscribe();
  }

}
