import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Store } from '@ngrx/store';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ChatState } from 'src/app/chat/state/reducer';
import { sendMessageFailedAction, sendMessageSuccessAction } from 'src/app/chat/state/actions';
import { SendMessage } from 'src/app/chat/models/request/send-message';

@Component({
  selector: 'app-message-input',
  templateUrl: './message-input.component.html',
  styleUrls: ['./message-input.component.scss'],
})
export class MessageInputComponent  implements OnInit {

  @Input() userId? : string;
  messageInput = new FormControl<string>("");
  userId$ = this.loginStore.select(selectUserId);

  constructor(
    private readonly loginStore : Store<LoginState>,
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<ChatState>
  ) { }

  ngOnInit() {}

  sendMessage(){

    this.userId$.pipe(first()).subscribe(userId => {

      if(this.messageInput.value && this.userId){

        var request : SendMessage = {
          id : crypto.randomUUID(),
          senderId : userId!,
          content : this.messageInput.value,
          receiverId : this.userId,
          sendDate : new Date().getTime()
        }

        this.chatHub.hubConnection!
          .invoke("SendMessage",request)
          .then(() => {
            this.chatStore.dispatch(sendMessageSuccessAction({request : request}))
          })
          .catch(() => this.chatStore.dispatch(sendMessageFailedAction()))
        this.messageInput.setValue('');
      }

    });

  }


}
