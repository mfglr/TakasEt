import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { register } from 'swiper/element/bundle';
import { Router } from '@angular/router';
import { LoginState } from './account/state/reducer';
import { selectIsLogin } from './account/state/selectors';
import { loginByLocalStorageAction } from './account/state/actions';
register();

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {

  isLogin$ : Observable<boolean> = this.loginStore.select(selectIsLogin);

  constructor(
    private loginStore : Store<LoginState>,
    private router : Router
  ) {}

  ngOnInit() {
    this.loginStore.dispatch(loginByLocalStorageAction())

    this.isLogin$.subscribe(
      islogin => {
        if(!islogin)
          this.router.navigateByUrl("/account/login")
        else
          this.router.navigateByUrl("/chat/home")
      }
    )
  }

  ngOnDestroy(){
  }

}
