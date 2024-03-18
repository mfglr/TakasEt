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

    this.hubConnection.onreconnected(() => {})

    this.hubConnection.on("connectionCompletedNotification",() => {
      this.chatStore.dispatch(connectionSuccessAction())
      this.hubConnection!.invoke("GetNewMessages");
    });

    this.hubConnection.on("synchronizedFailedNotification",() => {
      this.chatStore.dispatch(synchronizedFailedAction());
    })

    this.hubConnection.on("synchronizedSuccessNotification",() => {
      this.chatStore.dispatch(synchronizedSuccessAction());
    })

    this.hubConnection.on("receiveNewMessages",(response : AppResponse<MessageResponse[]>) => {

      var messages = response.data!.map(x => mapDateTimesOfMessageResponse(x));
      var receivedDate = new Date();
      var ids = Array.from(new Set(messages.filter(x => x.status != MessageStatus.Received).map(x => x.id)))

      this.chatStore.dispatch(loadNewMessagesSuccessAction({payload : messages,receivedDate : receivedDate}))
      this.hubConnection!.invoke("MarkMessagesAsReceived",{ids : ids,receivedDate : receivedDate.getTime()})
    });


    this.hubConnection.on("messageSaveCompletedNotification",(response : AppResponse<MessageResponse>) => {
      this.chatStore.dispatch(markMessageAsCreatedSuccessAction({message : mapDateTimesOfMessageResponse(response.data!)}))
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
      this.chatStore.dispatch(markMessageAsReceivedSuccessAction({
        payload : mapDateTimesOfMessageResponse(response.data!)
      }))
    })

    this.hubConnection.on("messageViewedNotification",(response : AppResponse<MessageResponse>) => {
      this.chatStore.dispatch(markMessageSentAsViewedAction({payload : mapDateTimesOfMessageResponse(response.data!)}))
    })

    this.hubConnection.on("messagesViewedNotification",(response : AppResponse<MessageResponse[]>) => {
      this.chatStore.dispatch(markMessagesSentAsViewedAction({
        payload : response.data!.map(x => mapDateTimesOfMessageResponse(x))
      }))
    });

  }


}
