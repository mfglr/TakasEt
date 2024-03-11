import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription, first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ChatState, MessageState, UserState, takeValueOfMessage } from '../../state/reducer';
import { markMessageAsViewedAction, markNewMessagesAsViewedAction, nextPageMessagesAction } from '../../state/actions';
import { selectForConversationPage } from '../../state/selectors';
import { Router } from '@angular/router';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit,OnDestroy {

  userId : string | null = null;
  receivedMessagesSubscription? : Subscription;
  conversation$? : Observable<{ userState? : UserState; messages: MessageState[];} | undefined>

  constructor(
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<ChatState>,
    private readonly router : Router
  ) {
    var state = this.router.getCurrentNavigation()?.extras.state;
    if(state)
      this.userId = state["userId"] as (string | null)
  }

  ngOnInit() {

    if(this.userId)
    {
      this.conversation$ = this.chatStore.select(selectForConversationPage({userId : this.userId}));

      this.conversation$.pipe(first()).subscribe(
        x => {
          if(!x || x.messages.length < takeValueOfMessage)
            this.chatStore.dispatch(nextPageMessagesAction({userId : this.userId!}))
        }
      )

      this.receivedMessagesSubscription = this.chatHub.receivedMessages.subscribe(message => {
        var viewedDate = new Date();
        this.chatStore.dispatch(markMessageAsViewedAction({
          messageId : message.id,receiverId : message.senderId,viewedDate : viewedDate
        }))

        if(message.senderId == this.userId)
          this.chatHub.hubConnection!.invoke( "SendMessageViewedNotification", message.id,message.senderId,viewedDate)
      })

      this.chatStore.dispatch(markNewMessagesAsViewedAction({
        receiverId : this.userId,
        viewedDate : new Date()
      }));

    }
  }

  ngOnDestroy(){
    this.receivedMessagesSubscription?.unsubscribe();
  }

}
