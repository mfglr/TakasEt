import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { State } from './state/reducer';
import { initPageAction } from './state/actions';
import { MessageResponse } from 'src/app/chat/models/responses/message-response';
import { Observable, first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ConversationResponse } from '../chat-home/models/responses/conversation-response';
import { ConversationService } from '../../services/conversation.service';
import { Chat } from '../../state/reducer';
import { nextPageMessagesAction } from '../../state/actions';
import { selectMessageResponses } from '../../state/selectors';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit {
  conversation : ConversationResponse | null;

  constructor(
    private readonly router : Router,
    private readonly store : Store<State>,
    private readonly conversationService : ConversationService,
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<Chat>
  ) {

    this.conversation = this.router.getCurrentNavigation()?.extras.state as (ConversationResponse | null)
  }

  messages$? : Observable<MessageResponse[]>;

  ngOnInit() {

    if(this.conversation){
      this.store.dispatch(initPageAction({userId : this.conversation.receiverId}));

      this.messages$ = this.chatStore.select(selectMessageResponses({receiverId : this.conversation.receiverId}));

      this.messages$.pipe(first()).subscribe(
        x => {
          if(x.length == 0)
            this.chatStore.dispatch(nextPageMessagesAction({receiverId : this.conversation!.receiverId}))
        }
      )
      if(this.conversation.countOfMessagesUnviewed > 0){
        this.conversationService.markMessagesAsViewed({userId : this.conversation.receiverId}).subscribe();
      }

      this.chatHub.hubConnection!.on("receiveMessage",(message : MessageResponse) => {
        if(message.senderId == this.conversation!.receiver!.id)
          this.chatHub.hubConnection!.invoke("SendMessageViewedNotification",message.id,message.senderId)
      })

    }
  }



}
