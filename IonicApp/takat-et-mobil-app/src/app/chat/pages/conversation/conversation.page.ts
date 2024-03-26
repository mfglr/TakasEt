import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription, first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ChatState, MessageState, UserState, numberOfMessagesPerPage } from '../../state/reducer';
import {
  nextPageMessagesAction, createMessageAction
} from '../../state/actions';
import { selectMessageStatesOfConversatinPage, selectUnviewedMessages } from '../../state/selectors';
import { Router } from '@angular/router';
import { mapDateTimesOfMessageResponse } from 'src/app/helpers/mapping-datetime';
import { MessageResponse } from '../../models/responses/message-response';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { CreateMessage } from '../../models/request/create-message';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit,OnDestroy {

  userState : UserState | undefined = undefined;
  receivedMessagesSubscription? : Subscription;
  messages$? : Observable<MessageState[]>
  messageInput = new FormControl<string>("");

  constructor(
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<ChatState>,
    private readonly loginStore : Store<LoginState>,
    private readonly router : Router
  ) {
    var state = this.router.getCurrentNavigation()?.extras.state;
    if(state)
      this.userState = state as (UserState | undefined)
  }

  ngOnInit() {

    if(this.userState){
      this.messages$ = this.chatStore.select(selectMessageStatesOfConversatinPage({userId : this.userState.id}));

      this.messages$.pipe(first()).subscribe(
        x => {
          if(x.length < numberOfMessagesPerPage)
            this.chatStore.dispatch(nextPageMessagesAction({user : this.userState!}))
        }
      )

      // this.chatStore.select(selectUnviewedMessages({userId : this.userState.id})).pipe(first()).subscribe(
      //   messages => {
      //     if(messages.length > 0){
      //       var viewedDate = new Date()
      //       this.chatStore.dispatch(markMessagesReceivedAsViewedAction({payload : messages,viewedDate : viewedDate}))
      //       this.chatHub.hubConnection!.invoke(
      //         "MarkNewMessagesAsViewed",{ids : messages.map(x => x.id),viewedDate : viewedDate.getTime()}
      //       )
      //     }
      //   }
      // )

      // this.receivedMessagesSubscription = this.chatHub.receivedMessages.subscribe(message => {
      //   var viewedDate = new Date();
      //   var message : MessageResponse = {...mapDateTimesOfMessageResponse(message),viewedDate : viewedDate};
      //   this.chatStore.dispatch(markMessageReceivedAsViewedAction({payload : message}))
      //   this.chatHub.hubConnection!.invoke("MarkMessageAsViewed",{messageId : message.id,viewedDate : viewedDate})
      // })

    }
  }

  ngOnDestroy(){
    this.receivedMessagesSubscription?.unsubscribe();
  }

  sendMessage(){
    this.loginStore.select(selectUserId).pipe(first()).subscribe(loginUserId => {
      if(this.messageInput.value && this.userState){

        var request : CreateMessage = {
          id : crypto.randomUUID(),
          content : this.messageInput.value,
          receiverId : this.userState.id,
          sendDate : new Date().getTime(),
          images : []
        }

        this.chatStore.dispatch(createMessageAction({
          senderId : loginUserId!,
          message : request,
          paths : [],
          userState : this.userState
        }))

        this.messageInput.setValue('');
      }
    });

  }

}
