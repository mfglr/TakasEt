import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { register } from 'swiper/element/bundle';
import { AppState } from './state/reducer';
import { loadUserAction, loginFromLocalStorageAction } from './state/actions';
import { selectIsLogin } from './state/selector';
import { ChatHubConnectionService } from './services/chat-hub-connection.service';
import { HubConnectionBuilder } from '@microsoft/signalr';
register();

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {


  private baseUrl : string = "https://localhost:7153/conversation";
  private hubConnection = new HubConnectionBuilder().withUrl(`${this.baseUrl}`).build();

  constructor() {

  }

  ngOnInit(){

    // user 1 : 6ae86a2a-8d86-429f-bb49-f033b6115c6d
    // user 2


    this.hubConnection.start().then(
      () => {
        this.hubConnection.invoke("Connect","e293d987-e1a5-487c-87d6-752122b46e03")
      }
    );
  }


  // isLogin$ : Observable<boolean> = this.appStore.select(selectIsLogin);

  // constructor(
  //   private appStore : Store<AppState>,
  //   private messageHub : ChatHubConnectionService,
  // ) {}

  // ngOnInit() {
  //   this.appStore.dispatch(loginFromLocalStorageAction())

  //   this.isLogin$.subscribe(isLogin => {
  //     if(isLogin){
  //       this.appStore.dispatch(loadUserAction())
  //       this.messageHub.start()
  //     }
  //   })
  // }

  // login(){}

  // ngOnDestroy(){
  //   this.messageHub.stop();
  // }

}
