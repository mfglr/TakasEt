import { Component } from '@angular/core';
import { UserState } from './states/user/state';
import { Store } from '@ngrx/store';
import { isLogin } from './states/user/selector';
import { loginByRefreshToken, loginFromLocalStorage } from './states/user/actions';
import { LoginResponse } from './models/responses/login-response';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent{
  isLogin$ = this.store.select(isLogin)

  constructor(
    private store : Store<UserState>,
  ) {}

  ngOnInit(){
    let data = localStorage.getItem('loginResponse');
    if(data){
      let loginResponse : LoginResponse = JSON.parse(data);
      if(new Date(loginResponse.expirationDateOfAccessToken).getTime() > Date.now())
        this.store.dispatch(loginFromLocalStorage());
      else
        this.store.dispatch(loginByRefreshToken({refreshToken : loginResponse.refreshToken}));
    }
  }


}
