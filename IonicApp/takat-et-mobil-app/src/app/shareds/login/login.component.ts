import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { login, loginFromLocalStorage } from 'src/app/states/login_state/actions';
import { AppLoginState } from 'src/app/states/login_state/state';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent  implements OnInit {

  loginForm = new FormGroup({
    email : new FormControl<string>(""),
    password : new FormControl<string>("")
  })
  
  constructor(
    private loginStore : Store<AppLoginState>
  ) {}

  login(){
    const formData = this.loginForm.value;
    this.loginStore.dispatch(login({email : formData.email!, password : formData.password! }))
  }

  ngOnInit() {
    this.loginStore.dispatch(loginFromLocalStorage())
  }

}
