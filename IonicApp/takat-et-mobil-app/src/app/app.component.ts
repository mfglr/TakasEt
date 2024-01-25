import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { register } from 'swiper/element/bundle';
import { AppState } from './states/reducer';
import { loadUserAction, loginFromLocalStorageAction } from './states/actions';
import { selectIsLogin } from './states/selector';
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
  ) {}

  ngOnInit() {
    this.appStore.dispatch(loginFromLocalStorageAction())

    this.isLogin$.subscribe(isLogin => {
      if(isLogin) this.appStore.dispatch(loadUserAction())
    })

  }

}
