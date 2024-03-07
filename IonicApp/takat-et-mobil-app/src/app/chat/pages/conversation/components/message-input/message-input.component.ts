import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Store } from '@ngrx/store';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { Chat } from 'src/app/chat/state/reducer';
import { sendMessageFailedAction, sendMessageSuccessAction } from 'src/app/chat/state/actions';

@Component({
  selector: 'app-message-input',
  templateUrl: './message-input.component.html',
  styleUrls: ['./message-input.component.scss'],
})
export class MessageInputComponent  implements OnInit {

  @Input() receiverId? : string;
  messageInput = new FormControl<string>("");
  userId$ = this.loginStore.select(selectUserId);

  constructor(
    private readonly loginStore : Store<LoginState>,
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<Chat>
  ) { }

  ngOnInit() {}

  sendMessage(){

    this.userId$.pipe(first()).subscribe(userId => {

      if(this.messageInput.value && this.receiverId){

        var request = {
          id : crypto.randomUUID(),
          senderId : userId!,
          content : this.messageInput.value,
          receiverId : this.receiverId,
          sendDate : new Date()
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
