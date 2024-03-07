import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { MessageResponse } from 'src/app/chat/models/responses/message-response';
import { Observable, Subscription, first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ConversationResponse } from '../../models/responses/conversation-response';
import { Chat, takeValueOfMessage } from '../../state/reducer';
import { markMessageAsViewedAction, markNewMessagesAsViewedAction, nextPageMessagesAction } from '../../state/actions';
import { selectMessageResponses } from '../../state/selectors';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit,OnDestroy {
  conversation : ConversationResponse | null;
  receivedMessagesSubscription? : Subscription;
  messages$? : Observable<MessageResponse[]>;

  constructor(
    private readonly router : Router,
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<Chat>
  ) {
    this.conversation = this.router.getCurrentNavigation()?.extras.state as (ConversationResponse | null)
  }

  ngOnInit() {

    if(this.conversation){
      this.messages$ = this.chatStore.select(selectMessageResponses({receiverId : this.conversation.receiverId}));
      this.messages$.pipe(first()).subscribe(
        x => {
          if(x.length < takeValueOfMessage)
            this.chatStore.dispatch(nextPageMessagesAction({receiverId : this.conversation!.receiverId}))
        }
      )

      this.receivedMessagesSubscription = this.chatHub.receivedMessages.subscribe(message => {
        var viewedDate = new Date();
        this.chatStore.dispatch(markMessageAsViewedAction({
          messageId : message.id,receiverId : message.senderId,viewedDate : viewedDate
        }))

        if(message.senderId == this.conversation!.receiverId)
          this.chatHub.hubConnection!.invoke( "SendMessageViewedNotification", message.id,message.senderId,viewedDate)
      })

      this.chatStore.dispatch(markNewMessagesAsViewedAction({
        receiverId : this.conversation.receiverId,
        viewedDate : new Date()
      }));

    }
  }

  ngOnDestroy(){
    this.receivedMessagesSubscription?.unsubscribe();
  }

}
