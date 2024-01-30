import { Injectable } from '@angular/core';
import { HubConnectionBuilder, HubConnectionState } from '@microsoft/signalr';
import { Store } from '@ngrx/store';
import { AppState } from '../state/reducer';
import { selectUserId } from '../state/selector';
import { Observable, Subject, first } from 'rxjs';
import { messageHubConnectionFailAction, messageHubConnectionSuccessAction } from '../state/actions';

@Injectable({
  providedIn : "root"
})
export class MessageHubConnectionService {

  private baseUrl : string = "https://localhost:7160/message";
  private hubConnection = new HubConnectionBuilder().withUrl(`${this.baseUrl}`).build();

  private subjects : {[key : string] : Subject<any>} = {};
  private mehtodNames : string[] = []
  private index = 0;

  userId$ = this.appStore.select(selectUserId);
  constructor(private appStore : Store<AppState>) {}

  start(){
    this.userId$.pipe(first()).subscribe(
      userId => {
        if(userId != undefined){
          if(this.hubConnection.state == HubConnectionState.Disconnected){

            this.hubConnection.start()
              .then(
                () => {
                  this.hubConnection.invoke("AddUserSignalRState",userId);
                  this.appStore.dispatch(messageHubConnectionSuccessAction());
                }
              )
              .catch( () => this.appStore.dispatch(messageHubConnectionFailAction()) )
          }
        }
        setTimeout(() => this.start(),3000)
      }
    )
  }

  on<T>(methodName : string) : Observable<T>{
    if(!this.subjects[methodName]){
      this.mehtodNames[this.index++] = methodName;
      this.subjects[methodName] = new Subject<T>();
      this.hubConnection.on( methodName, data => {
        this.subjects[methodName].next(data)
      });
    }
    return this.subjects[methodName]
  }

  invoke(methodName : string,data : string){
    this.hubConnection.invoke(methodName,data)
  }

  stop(){
    this.hubConnection.stop();
    for(let i = 0; i < this.index;i++)
      this.subjects[this.mehtodNames[i]].complete();
  }

}
