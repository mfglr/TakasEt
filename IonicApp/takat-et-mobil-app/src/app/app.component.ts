import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { register } from 'swiper/element/bundle';
import { LoginState } from './login/state/reducer';
import { selectIsLogin } from './login/state/selectors';
import { loginByLocalStorageAction } from './login/state/actions';
import { Router } from '@angular/router';
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
        console.log(islogin);
        if(!islogin)
          this.router.navigateByUrl("/login")
        else
          this.router.navigateByUrl("/messages")
      }
    )
  }

  ngOnDestroy(){
  }

}
