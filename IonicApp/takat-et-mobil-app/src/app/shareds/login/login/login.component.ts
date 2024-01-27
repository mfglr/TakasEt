import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { loginAction } from 'src/app/state/actions';
import { AppState } from 'src/app/state/reducer';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent{

  loginForm = new FormGroup({
    email : new FormControl<string>(""),
    password : new FormControl<string>("")
  })

  constructor(
    private appStore : Store<AppState>,
  ) {}

  login(){
    const formData = this.loginForm.value;
    this.appStore.dispatch(loginAction({email : formData.email!, password : formData.password! }))
  }
}
