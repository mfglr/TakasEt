import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { MessageResponse, MessageStatus } from '../chat/models/responses/message-response';
import {
  connectionFailedAction, connectionSuccessAction, markMessageAsCreatedSuccessAction,
  receiveMessageSuccessAction,
  markMessageAsReceivedSuccessAction, markMessageSentAsViewedAction, markMessagesSentAsViewedAction,
  loadNewMessagesSuccessAction, synchronizedFailedAction, synchronizedSuccessAction
} from '../chat/state/actions';
import { Subject } from 'rxjs';
import { ChatState } from '../chat/state/reducer';
import { AppResponse } from '../models/responses/app-response';
import { mapDateTimesOfMessageResponse } from '../helpers/mapping-datetime';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn : "root" })
export class ChatHubService {

  private baseUrl : string = environment.messageHub;

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
      .then(() => {})
      .catch((e) => this.chatStore.dispatch(connectionFailedAction()));

    this.hubConnection.onclose(() => {
      this.chatStore.dispatch(connectionFailedAction())
    })

    this.hubConnection.onreconnected(() => {})

    this.hubConnection.on("connectionCompletedNotification",() => {
      this.chatStore.dispatch(connectionSuccessAction())
    });

    this.hubConnection.on("messageCreationCompletedNotification",(response : MessageResponse) => {
      this.chatStore.dispatch(markMessageAsCreatedSuccessAction({message : mapDateTimesOfMessageResponse(response)}))
    })

    this.hubConnection.on("receiveMessage",(response : MessageResponse) => {

      var message : MessageResponse = {...mapDateTimesOfMessageResponse(response),receivedDate : new Date()};
      this.receivedMessagesSubject.next(message);

      this.chatStore.dispatch(receiveMessageSuccessAction({payload : message}))

      this.hubConnection!.invoke(
        "MarkMessageAsReceived",
        { messageId : message.id, receivedDate : message.receivedDate!}
      )
    })

    this.hubConnection.on("messageReceivedNotification",(response : MessageResponse) => {
      this.chatStore.dispatch(markMessageAsReceivedSuccessAction({
        payload : mapDateTimesOfMessageResponse(response)
      }))
    })

    this.hubConnection.on("messageViewedNotification",(response : MessageResponse) => {
      this.chatStore.dispatch(markMessageSentAsViewedAction({payload : mapDateTimesOfMessageResponse(response)}))
    })

  }


}
