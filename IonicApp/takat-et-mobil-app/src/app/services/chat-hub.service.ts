import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { MessageResponse } from '../chat/models/responses/message-response';
import {
  connectionFailedAction, connectionSuccessAction, markMessageAsCreatedSuccessAction, markMessageAsViewedAction,
  markMessagesAsViewedAction,loadNewMessagesAction,receiveMessageSuccessAction, markMessageAsReceivedSuccessAction, markMessageAsViewedSuccessAction, markMessagesAsReceivedAction, markMessagesAsReceivedSuccessAction, markMessagesAsViewedSuccessAction, loadNewMessagesSuccessAction
} from '../chat/state/actions';
import { Subject } from 'rxjs';
import { ChatState } from '../chat/state/reducer';
import { AppResponse } from '../models/responses/app-response';
import { mapDateTimesOfMessageResponse } from '../helpers/mapping-datetime';

@Injectable({ providedIn : "root" })
export class ChatHubService {

  private baseUrl : string = "https://localhost:7200/message";
  hubConnection? : HubConnection
  private receivedMessagesSubject = new Subject<MessageResponse>();

  public receivedMessages = this.receivedMessagesSubject.asObservable();

  constructor(
    private readonly chatStore : Store<ChatState>
  ) {
  }

  start(token : string){
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${this.baseUrl}`,{ accessTokenFactory : () => token })
      .build()

    this.hubConnection
      .start()
      .then()
      .catch((e) => this.chatStore.dispatch(connectionFailedAction()));

    this.hubConnection.onclose(() => {
      this.chatStore.dispatch(connectionFailedAction())
    })

    this.hubConnection.onreconnected(() => {

    })

    this.hubConnection.on("connectionCompletedNotification",() => {
      this.chatStore.dispatch(connectionSuccessAction())
    });

    this.hubConnection.on("messageSaveCompletedNotification",(message : AppResponse<MessageResponse>) => {
      this.chatStore.dispatch(markMessageAsCreatedSuccessAction({message : mapDateTimesOfMessageResponse(message.data!)}))
    })

    this.hubConnection.on("receiveMessage",(response : AppResponse<MessageResponse>) => {

      var message : MessageResponse = {...mapDateTimesOfMessageResponse(response.data!),receivedDate : new Date()};
      this.receivedMessagesSubject.next(message);

      this.chatStore.dispatch(receiveMessageSuccessAction({payload : message}))

      this.hubConnection!.invoke(
        "SendMessageReceivedNotification",{ messageId : message.id, receivedDate : message.receivedDate!}
      )
    })

    this.hubConnection.on("messageReceivedNotification",(response : AppResponse<MessageResponse>) => {
      this.chatStore.dispatch(markMessageAsReceivedSuccessAction({payload : mapDateTimesOfMessageResponse(response.data!)}))
    })

    this.hubConnection.on("messageViewedNotification",(response : AppResponse<MessageResponse>) => {
      this.chatStore.dispatch(markMessageAsViewedSuccessAction({payload : mapDateTimesOfMessageResponse(response.data!)}))
    })

  }


}
