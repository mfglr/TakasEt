import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { register } from 'swiper/element/bundle';
import { isLogin } from './states/login_state/selectors';
import { LoginState } from './states/login_state/reducer';
import { loginFromLocalStorage } from './states/login_state/actions';
register();

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  
  isLogin$? : Observable<boolean> = this.loginStore.select(isLogin);
  
  constructor(
    private loginStore : Store<LoginState>,
  ) {}

  ngOnInit() {
    this.loginStore.dispatch(loginFromLocalStorage())
  }

  
}
