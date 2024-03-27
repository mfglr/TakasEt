import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { MessageResponse, MessageStatus } from '../chat/models/responses/message-response';
import {
  changeHubConnectionStateAction,
  receiveMessageAction,
  markMessageSentAsViewedAction,
  markMessageSentAsReceivedAction,
  viewMessageAction,
} from '../chat/state/actions';
import { Subject, filter, from, mergeMap } from 'rxjs';
import { ChatState, numberOfMessagesPerPage } from '../chat/state/reducer';
import { mapDateTimesOfMessageResponse, mapDateTimesOfMessageResponses } from '../helpers/mapping-datetime';
import { environment } from 'src/environments/environment';
import { AppResponse } from '../models/responses/app-response';

@Injectable({ providedIn : "root" })
export class ChatHubService {

  private baseUrl : string = environment.messageHub;

  hubConnection? : HubConnection
  private newMessagesSubject = new Subject<MessageResponse>();
  private unviewedMessageSubject = new Subject<MessageResponse>();
  public viewedMessagesSubject = new Subject<string>();

  public newMessages = this.newMessagesSubject.asObservable();
  public unviewedMessages = this.unviewedMessageSubject.asObservable();



  constructor(private readonly chatStore : Store<ChatState>) {}

  private getNewMessages(lastDate? : Date){
    this.hubConnection!.invoke(
      "GetNewMessages",
      {take : numberOfMessagesPerPage,lastValue : lastDate?.getTime(),isDescending : false}
    ).then(
      (response : AppResponse<MessageResponse[]>) => {
        let messages = mapDateTimesOfMessageResponses(response.data!);

        for(let i = 0; i < messages.length;i++)
          this.newMessagesSubject.next(messages[i])

        if(messages.length >= numberOfMessagesPerPage)
          this.getNewMessages(messages[messages.length - 1].sendDate)
      }
    )
  }

  private markNewMessagesAsReceived(){
    this.newMessages.subscribe(async message => {
      if(message.status == MessageStatus.Created){
        var receivedDate = new Date();
        await this.hubConnection!.invoke<AppResponse<MessageResponse>>(
          "MarkMessageAsReceived",
          {senderId : message.senderId,messageId : message.id,receivedDate : receivedDate}
        )
        this.chatStore.dispatch(receiveMessageAction({payload : message,receivedDate : receivedDate}))
      }
      else
        this.chatStore.dispatch(receiveMessageAction({payload : message,receivedDate : message.receivedDate!}))

      this.unviewedMessageSubject.next(message);
    })
  }

  private markNewMessageAsViewed(){
    this.viewedMessagesSubject.subscribe(async id => {
      var viewedDate = new Date();
      await this.hubConnection!.invoke("markMessageAsViewed",{messageId : id,viewedDate : viewedDate.getTime()})
      this.chatStore.dispatch(viewMessageAction({id : id,viewedDate : viewedDate}));
    })
  }

  start(token : string){

    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${this.baseUrl}`,{ accessTokenFactory : () => token })
      .build()

    this.hubConnection.start()
      .then(() => {
        this.chatStore.dispatch(changeHubConnectionStateAction({payload : this.hubConnection!.state}))
        this.markNewMessagesAsReceived()
        this.markNewMessageAsViewed()
        this.getNewMessages();
      })

    this.hubConnection.onclose(() => {this.chatStore.dispatch(changeHubConnectionStateAction({
      payload : this.hubConnection!.state}))
    })

    this.hubConnection.onreconnected(
      () =>{
        this.chatStore.dispatch(changeHubConnectionStateAction({payload : this.hubConnection!.state}))
        this.getNewMessages();
      }
    )

    this.hubConnection.on("receiveMessage",(response : MessageResponse) => {
      this.newMessagesSubject.next(mapDateTimesOfMessageResponse(response));
    })

    this.hubConnection.on("messageReceivedNotification",(response : MessageResponse) => {
      this.chatStore.dispatch(markMessageSentAsReceivedAction({
        messageId : response.id ,receivedDate : new Date(response.receivedDate!)
      }))
    })

    this.hubConnection.on("messageViewedNotification",(response : MessageResponse) => {
      this.chatStore.dispatch(markMessageSentAsViewedAction({
        messageId : response.id,viewedDate : new Date(response.viewedDate!)
      }))
    })

  }


}
