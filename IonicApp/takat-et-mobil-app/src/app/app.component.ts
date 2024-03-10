import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { register } from 'swiper/element/bundle';
import { Router } from '@angular/router';
import { LoginState } from './account/state/reducer';
import { selectAccessToken, selectIsLogin } from './account/state/selectors';
import { loginByLocalStorageAction } from './account/state/actions';
import { ChatHubService } from './services/chat-hub.service';
import { ChatState } from './chat/state/reducer';
import { loadNewMessagesAction } from './chat/state/actions';

register();

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {

  isLogin$ : Observable<boolean> = this.loginStore.select(selectIsLogin);
  accessToken$ = this.loginStore.select(selectAccessToken);

  constructor(
    private loginStore : Store<LoginState>,
    private chatStore : Store<ChatState>,
    private readonly chatHub : ChatHubService,
    private readonly router : Router,
  ) {}

  ngOnInit() {

    this.loginStore.dispatch(loginByLocalStorageAction())

    this.accessToken$.subscribe(
      token => {
        if(token){
          this.router.navigateByUrl("/chat/home")
          this.chatHub.start(token);
          this.chatStore.dispatch(loadNewMessagesAction())
        }
        else
          this.router.navigateByUrl("/account/login")
      }
    )
  }

  ngOnDestroy(){
    this.chatHub.hubConnection?.stop();
  }

}
