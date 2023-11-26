import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { register } from 'swiper/element/bundle';
import { AppLoginState } from './states/login_state/state';
import { Store } from '@ngrx/store';
import { isLogin } from './states/login_state/selectors';
import { login, loginFromLocalStorage } from './states/login_state/actions';
register();

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  
  loginForm = new FormGroup({
    email : new FormControl<string>(""),
    password : new FormControl<string>("")
  })
  isLogin$ = this.loginStore.select(isLogin);
  
  constructor(
    private loginStore : Store<AppLoginState>
  ) {}

  login(){
    const formData = this.loginForm.value;
    this.loginStore.dispatch(login({email : formData.email!, password : formData.password! }))
    console.log("a")
  }

  ngOnInit() {
    this.loginStore.dispatch(loginFromLocalStorage())
  }
}
