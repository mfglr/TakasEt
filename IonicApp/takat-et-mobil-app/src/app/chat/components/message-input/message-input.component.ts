import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Store } from '@ngrx/store';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { first } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ChatState, UserState } from 'src/app/chat/state/reducer';
import { sendMessageFailedAction, sendMessageSuccessAction } from 'src/app/chat/state/actions';
import { SendMessage } from 'src/app/chat/models/request/send-message';
import { PhotoService } from 'src/app/services/photo-service';
import { Photo } from '@capacitor/camera';

@Component({
  selector: 'app-message-input',
  templateUrl: './message-input.component.html',
  styleUrls: ['./message-input.component.scss'],
})
export class MessageInputComponent implements OnInit {
  @Input() cameraIcon : boolean = true;
  @Input() userState? : UserState | null;
  @Output() photoEvent = new EventEmitter<Photo>();
  messageInput = new FormControl<string>("");
  loginUserId$ = this.loginStore.select(selectUserId);

  constructor(
    private readonly loginStore : Store<LoginState>,
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<ChatState>,
    private readonly photoService : PhotoService,
  ) { }

  ngOnInit() {}

  sendMessage(){
    this.loginUserId$.pipe(first()).subscribe(loginUserId => {
      if(this.messageInput.value && this.userState){

        var request : SendMessage = {
          id : crypto.randomUUID(),
          senderId : loginUserId!,
          content : this.messageInput.value,
          receiverId : this.userState.id,
          sendDate : new Date().getTime()
        }

        this.chatHub.hubConnection!
          .invoke("CreateMessage",request)
          .then(() => {
            this.chatStore.dispatch(sendMessageSuccessAction({
              request : request,userState : {...this.userState!}
            }))
          })
          .catch((e) => {
            this.chatStore.dispatch(sendMessageFailedAction())
          })
        this.messageInput.setValue('');
      }

    });

  }

  takeAPhoto(){
    this.photoService.takeAPhoto()
    .then(photo => this.photoEvent.emit(photo))
    .catch(e => console.log(e));
  }
}
