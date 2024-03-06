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
import { MessageResponse } from './chat/models/responses/message-response';
import { ChatHubService } from './services/chat-hub.service';
import { ConversationPageState } from './chat/pages/conversation/state/reducer';
import { markAsReceivedAction, markAsSavedAction, markAsViewedAction, markMessagesAsViewedAction, receiveMessageAction } from './chat/pages/conversation/state/actions';

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

    hubConnection.on("connectionCompletedNotification",() => {
      this.chatHubStore.dispatch(connectionSuccessAction())
    });

    hubConnection.on("messageSaveCompletedNotification",(message : MessageResponse) => {
      this.conversationPageStore.dispatch(markAsSavedAction({
        messageId : message.id,userId : message.receiverId
      }))
    })

    hubConnection.on("receiveMessage",(message : MessageResponse) => {
      hubConnection.invoke("SendMessageReceivedNotification",message.id,message.senderId)
      this.conversationPageStore.dispatch(receiveMessageAction({payload : message}))
    })

    hubConnection.on("messageReceivedNotification",(data : {messageId : string,receiverId : string}) => {
      this.conversationPageStore.dispatch(markAsReceivedAction(data))
    })

    hubConnection.on("messageViewedNotification",(data : {messageId : string,receiverId : string}) => {
      this.conversationPageStore.dispatch(markAsViewedAction(data))
    })

    hubConnection.on("messagesViewedNotification",(data : {receiverId : string,ids : string[]}) => {
      this.conversationPageStore.dispatch(markMessagesAsViewedAction(data));
    })
  }

  ngOnDestroy(){
    this.chatHub.hubConnection?.stop();
  }

}
