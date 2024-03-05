import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { register } from 'swiper/element/bundle';
import { Router } from '@angular/router';
import { LoginState } from './account/state/reducer';
import { selectAccessToken, selectIsLogin } from './account/state/selectors';
import { loginByLocalStorageAction } from './account/state/actions';
import { ChatHubState } from './state/chat-hub-state/reducer';
import { connectionSuccessAction } from './state/chat-hub-state/actions';
import { MessageResponse } from './models/responses/message-response';
import { ChatHubService } from './services/chat-hub.service';
import { SendMessageReceivedNotification } from './chat/models/request/sed-message-received-notification';
import { ConversationPageState } from './chat/pages/conversation/state/reducer';
import { markAsReceivedAction, markAsSavedAction, receiveMessageAction } from './chat/pages/conversation/state/actions';
import { AppResponse } from './models/responses/app-response';
register();

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {

  isLogin$ : Observable<boolean> = this.loginStore.select(selectIsLogin);
  accessToken$ = this.loginStore.select(selectAccessToken);

  constructor(
    private loginStore : Store<LoginState>,
    private readonly chatHub : ChatHubService,
    private readonly router : Router,
    private readonly conversationPageStore : Store<ConversationPageState>,
    private readonly chatHubStore : Store<ChatHubState>
  ) {}

  ngOnInit() {


    this.loginStore.dispatch(loginByLocalStorageAction())

    this.accessToken$.subscribe(
      async token => {
        if(token){
          this.router.navigateByUrl("/chat/home")
          await this.startChatHub(token);
        }
        else
          this.router.navigateByUrl("/account/login")
      }
    )
  }

  private async startChatHub(token : string){
    var hubConnection = this.chatHub.buildConnection(token)
    await this.chatHub.start();

    hubConnection.on("connectionCompleted",() => {
      this.chatHubStore.dispatch(connectionSuccessAction())
      console.log("connected");
    });

    hubConnection.on("messageSaveCompleted",(data : AppResponse<MessageResponse>) => {
      this.conversationPageStore.dispatch(markAsSavedAction({payload : data.data!}))
    })

    hubConnection.on("receiveMessage",(data  : AppResponse<MessageResponse>) => {

      var request : SendMessageReceivedNotification = {
        conversationId : data.data!.conversationId,
        messageId : data.data!.id
      }
      hubConnection.invoke("SendMessageReceivedNotification",request)
      this.conversationPageStore.dispatch(receiveMessageAction({receiverId : data.data!.senderId, payload : data.data!}))
    })

    hubConnection.on("messageReceived",(data : AppResponse<MessageResponse>) => {
      this.conversationPageStore.dispatch(markAsReceivedAction({receiverId : data.data!.receiverId,payload : data.data!}))
    })

  }


  ngOnDestroy(){
  }

}
