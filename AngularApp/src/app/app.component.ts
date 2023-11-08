import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginResponse } from './models/responses/login-response';
import { isLogin } from './states/login_state/selectors';
import { AppLoginState } from './states/login_state/state';
import { loadProfileImage, loginByRefreshToken, loginFromLocalStorage } from './states/login_state/actions';
import { filter, first, map, skipWhile, takeUntil, takeWhile } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent{
  isLogin$ = this.loginStore.select(isLogin)
  
  getProfileImage$ = this.isLogin$.pipe(
    filter(isLogin => isLogin),
    first(),
    map( () => this.loginStore.dispatch(loadProfileImage()) )
  )

  constructor(
    private loginStore : Store<AppLoginState>,
  ) {}

  ngOnInit(){
    let data = localStorage.getItem('login_response');
    if(data){
      let loginResponse : LoginResponse = JSON.parse(data);
      if(new Date(loginResponse.expirationDateOfAccessToken).getTime() > Date.now())
        this.loginStore.dispatch(loginFromLocalStorage());
      else
        this.loginStore.dispatch(loginByRefreshToken({refreshToken : loginResponse.refreshToken}));
      this.getProfileImage$.subscribe();
    }
  }


}
