import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { MessageResponse, MessageStatus } from '../chat/models/responses/message-response';
import {
  changeHubConnectionStateAction,
  loadNewMessagesAction,
  receiveMessageAction,
  markMessageSentAsViewedAction,
  markMessageSentAsReceivedAction
} from '../chat/state/actions';
import { Subject, filter, mergeMap } from 'rxjs';
import { ChatState, numberOfMessagesPerPage } from '../chat/state/reducer';
import { mapDateTimesOfMessageResponse, mapDateTimesOfMessageResponses } from '../helpers/mapping-datetime';
import { environment } from 'src/environments/environment';
import { AppResponse } from '../models/responses/app-response';

@Injectable({ providedIn : "root" })
export class ChatHubService {

  private baseUrl : string = environment.messageHub;

  hubConnection? : HubConnection
  private receivedMessagesSubject = new Subject<MessageResponse>();

  public receivedMessages = this.receivedMessagesSubject.asObservable();

  constructor(private readonly chatStore : Store<ChatState>) {}

  private getNewMessages(lastValue? : Date){
    this.hubConnection!.invoke(
      "GetNewMessages",
      {take : numberOfMessagesPerPage,lastValue : lastValue?.getTime(),isDescending : false}
    ).then(
      (response : AppResponse<MessageResponse[]>) => {

        let messages = mapDateTimesOfMessageResponses(response.data!);
        this.chatStore.dispatch(loadNewMessagesAction({payload : messages,receivedDate : new Date()}))

        for(let i = 0; i < messages.length;i++)
          this.receivedMessagesSubject.next(messages[i])

        if(messages.length >= numberOfMessagesPerPage)
          this.getNewMessages(messages[messages.length - 1].sendDate)
      }
    )
  }

  private markNewMessagesAsReceived(){
    // this.receivedMessages.pipe(
    //   filter(message => message.status == MessageStatus.Created),
    //   mergeMap(
    //     message => this.hubConnection!.invoke(
    //       "MarkMessageAsReceived",
    //       {senderId : message.senderId,messageId : message.id, receivedDate : message.receivedDate!}
    //     )
    //   ),
    //   mergeMap((response : AppResponse<MessageResponse>) => )
    // )
  }


  start(token : string){

    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${this.baseUrl}`,{ accessTokenFactory : () => token })
      .build()

    this.hubConnection.start()
      .then(() => {

        this.chatStore.dispatch(changeHubConnectionStateAction({payload : this.hubConnection!.state}))
        // this.markNewMessagesAsReceived();
        this.getNewMessages();

      })

    this.hubConnection.onclose(
      () => {
        this.chatStore.dispatch(changeHubConnectionStateAction({payload : this.hubConnection!.state}))
      }
    )

    this.hubConnection.onreconnected(
      () =>{
        this.chatStore.dispatch(changeHubConnectionStateAction({payload : this.hubConnection!.state}))
        this.getNewMessages();
      }
    )

    // this.hubConnection.on("receiveMessage",(response : MessageResponse) => {
    //   var message : MessageResponse = {...mapDateTimesOfMessageResponse(response),receivedDate : new Date()};
    //   this.chatStore.dispatch(receiveMessageAction({payload : message,receivedDate : new Date()}))
    //   this.receivedMessagesSubject.next(message);
    // })

    // this.hubConnection.on("messageReceivedNotification",(response : MessageResponse) => {
    //   this.chatStore.dispatch(markMessageSentAsReceivedAction({
    //     messageId : response.id ,receivedDate : new Date(response.receivedDate!)
    //   }))
    // })

    // this.hubConnection.on("messageViewedNotification",(response : MessageResponse) => {
    //   this.chatStore.dispatch(markMessageSentAsViewedAction({
    //     messageId : response.id,viewedDate : new Date(response.viewedDate!)
    //   }))
    // })

  }


}
