import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { register } from 'swiper/element/bundle';
import { AppState } from './state/reducer';
import { loadUserAction, loginFromLocalStorageAction } from './state/actions';
import { selectIsLogin } from './state/selector';
import { ChatHubConnectionService } from './services/chat-hub-connection.service';
register();

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {

  isLogin$ : Observable<boolean> = this.appStore.select(selectIsLogin);

  constructor(
    private appStore : Store<AppState>,
    private messageHub : ChatHubConnectionService,
  ) {}

  ngOnInit() {
    this.appStore.dispatch(loginFromLocalStorageAction())

    this.isLogin$.subscribe(isLogin => {
      if(isLogin){
        this.appStore.dispatch(loadUserAction())
        this.messageHub.start()
      }
    })

  }

  login(){
  }

  ngOnDestroy(){
    this.messageHub.stop();
  }

}
