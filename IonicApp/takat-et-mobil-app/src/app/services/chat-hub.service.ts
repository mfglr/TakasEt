import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { ChatHubState } from '../state/chat-hub-state/reducer';
import { connectionFailedAction, connectionSuccessAction } from '../state/chat-hub-state/actions';
import { Chat } from '../chat/state/reducer';
import { MessageResponse } from '../chat/models/responses/message-response';
import { markMessageAsCreatedAction, markMessageAsReceivedAction, markMessageAsViewedAction, markMessagesAsViewedAction, receiveMessageAction } from '../chat/state/actions';
import { Subject } from 'rxjs';

@Injectable({ providedIn : "root" })
export class ChatHubService {

  private baseUrl : string = "https://localhost:7200/conversation";
  hubConnection? : HubConnection
  private receivedMessagesSubject = new Subject<MessageResponse>();

  public receivedMessages = this.receivedMessagesSubject.asObservable();

  constructor(
    private readonly chatHubStore : Store<ChatHubState>,
    private readonly chatStore : Store<Chat>
  ) {
  }

  async start(token : string){
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${this.baseUrl}`,{ accessTokenFactory : () => token })
      .build()

    this.chatHubStore.dispatch(connectionFailedAction())
    this.hubConnection
      .start()
      .catch((e) => this.chatHubStore.dispatch(connectionFailedAction()));

    this.hubConnection.on("connectionCompletedNotification",() => {
      this.chatHubStore.dispatch(connectionSuccessAction())
    });

    this.hubConnection.on("messageSaveCompletedNotification",(message : MessageResponse) => {
      this.chatStore.dispatch(markMessageAsCreatedAction({messageId : message.id,receiverId : message.receiverId}))
    })

    this.hubConnection.on("receiveMessage",(message : MessageResponse) => {

      message.receivedDate = new Date()
      this.receivedMessagesSubject.next(message);

      this.chatStore.dispatch(receiveMessageAction({payload : message}))
      this.hubConnection!.invoke(
        "SendMessageReceivedNotification",
        message.id,message.senderId,message.receivedDate
      )
    })

    this.hubConnection.on("messageReceivedNotification",(data : {messageId : string,receiverId : string,receivedDate : Date}) => {
      this.chatStore.dispatch(markMessageAsReceivedAction(data))
    })

    this.hubConnection.on("messageViewedNotification",(data : {messageId : string,receiverId : string,viewedDate : Date}) => {
      this.chatStore.dispatch(markMessageAsViewedAction(data))
    })

    this.hubConnection.on("messagesViewedNotification",(data : {receiverId : string,ids : string[],viewedDate : Date}) => {
      this.chatStore.dispatch(markMessagesAsViewedAction(data));
    })

  }


}
