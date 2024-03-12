import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription, first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ChatState, MessageState, UserState, takeValueOfMessage } from '../../state/reducer';
import { markMessageAsViewedAction, markNewMessagesAsViewedAction, nextPageMessagesAction } from '../../state/actions';
import { selectMessageStatesOfConversatinPage } from '../../state/selectors';
import { Router } from '@angular/router';

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

    if(this.userState)
    {
      this.messages$ = this.chatStore.select(selectMessageStatesOfConversatinPage({userId : this.userState.id}));

      this.messages$.pipe(first()).subscribe(
        x => {
          if(!x || x.length < takeValueOfMessage)
            this.chatStore.dispatch(nextPageMessagesAction({userId : this.userState!.id}))
        }
      )

      this.receivedMessagesSubscription = this.chatHub.receivedMessages.subscribe(message => {
        var viewedDate = new Date();
        this.chatStore.dispatch(markMessageAsViewedAction({
          messageId : message.id,receiverId : message.senderId,viewedDate : viewedDate
        }))

        if(message.senderId == this.userState!.id)
          this.chatHub.hubConnection!.invoke( "SendMessageViewedNotification", message.id,message.senderId,viewedDate)
      })

      this.chatStore.dispatch(markNewMessagesAsViewedAction({
        receiverId : this.userState!.id,
        viewedDate : new Date()
      }));

    }
  }

  ngOnDestroy(){
    this.receivedMessagesSubscription?.unsubscribe();
  }

}
