import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginState } from './shareds/login/login_state/reducer';
import { Observable } from 'rxjs';
import { isLogin } from './shareds/login/login_state/selectors';
import { loginFromLocalStorage } from './shareds/login/login_state/actions';

import { register } from 'swiper/element/bundle';
register();

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  
  isLogin$? : Observable<boolean> = this.loginStore.select(isLogin);
  
  constructor(
    private loginStore : Store<LoginState>
  ) {}

  ngOnInit() {
    this.loginStore.dispatch(loginFromLocalStorage())
  }
}
