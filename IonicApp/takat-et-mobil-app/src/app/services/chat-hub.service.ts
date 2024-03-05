import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState} from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { ChatHubState } from '../state/chat-hub-state/reducer';
import { connectionFailedAction } from '../state/chat-hub-state/actions';

@Injectable({
  providedIn : "root"
})
export class ChatHubService {

  private baseUrl : string = "https://localhost:7200/conversation";
  private isStarted : boolean = false;
  hubConnection? : HubConnection

  constructor( private readonly chatHubStore : Store<ChatHubState>) {}


  buildConnection(token : string){
    if(!this.hubConnection)
      return this.hubConnection = new HubConnectionBuilder()
        .withUrl(`${this.baseUrl}`,{ accessTokenFactory : () => token })
        .build()
    return this.hubConnection;
  }

  async start(){

    if(!this.isStarted)
      setInterval(() => {
        if(this.hubConnection && this.hubConnection.state == HubConnectionState.Disconnected){
          this.isStarted = true;
          this.chatHubStore.dispatch(connectionFailedAction())
          this.hubConnection
            .start()
            .catch((e) => this.chatHubStore.dispatch(connectionFailedAction()));
        }
      },3000)

  }


}
