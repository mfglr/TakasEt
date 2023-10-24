import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable()
export class AppHubConnectionService {

  private static baseUrl : string = "http://localhost:5027";
  private hubConnection? : HubConnection;
  private subjects : {[key : string] : Subject<any>} = {};
  private mehtodsName : string[] = []
  private index = 0;

  create(url : string){
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${AppHubConnectionService.baseUrl}/${url}`)
      .build();
  }

  async start(){
    this.hubConnection?.start().catch( () => setTimeout(() => this.start(), 4000) )
  }

  invoke<T>(method : string,data : T) : void{
    this.hubConnection?.invoke(method,data);
  }

  on<T>(method : string,first : T) : Observable<T>{
    this.subjects[method] = new BehaviorSubject<T>(first);
    this.mehtodsName[this.index++] = method;
    this.hubConnection?.on( method, data => {
      this.subjects[method].next(data)
    });
    return this.subjects[method]
  }

  stop() : void{
    this.hubConnection?.stop();
    for(let i = 0; i < this.index; i++)
      this.subjects[this.mehtodsName[i]].complete();
  }
}
