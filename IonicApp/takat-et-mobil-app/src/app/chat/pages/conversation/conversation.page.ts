import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, Subscription, first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ConversationResponse } from '../../models/responses/conversation-response';
import { ChatState, MessageState, takeValueOfMessage } from '../../state/reducer';
import { markMessageAsViewedAction, markNewMessagesAsViewedAction, nextPageMessagesAction } from '../../state/actions';
import { selectMessageStates } from '../../state/selectors';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit,OnDestroy {
  conversation : ConversationResponse | null;
  receivedMessagesSubscription? : Subscription;
  messages$? : Observable<MessageState[]>;

  constructor(
    private readonly router : Router,
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<ChatState>
  ) {
    this.conversation = this.router.getCurrentNavigation()?.extras.state as (ConversationResponse | null)
  }

  ngOnInit() {

    if(this.conversation){
      this.messages$ = this.chatStore.select(selectMessageStates({userId : this.conversation.userId}));
      this.messages$.pipe(first()).subscribe(
        x => {
          if(x.length < takeValueOfMessage)
            this.chatStore.dispatch(nextPageMessagesAction({userId : this.conversation!.userId}))
        }
      )

      this.receivedMessagesSubscription = this.chatHub.receivedMessages.subscribe(message => {
        var viewedDate = new Date();
        this.chatStore.dispatch(markMessageAsViewedAction({
          messageId : message.id,receiverId : message.senderId,viewedDate : viewedDate
        }))

        if(message.senderId == this.conversation!.userId)
          this.chatHub.hubConnection!.invoke( "SendMessageViewedNotification", message.id,message.senderId,viewedDate)
      })

      this.chatStore.dispatch(markNewMessagesAsViewedAction({
        receiverId : this.conversation.userId,
        viewedDate : new Date()
      }));

    }
  }

  ngOnDestroy(){
    this.receivedMessagesSubscription?.unsubscribe();
  }

}
