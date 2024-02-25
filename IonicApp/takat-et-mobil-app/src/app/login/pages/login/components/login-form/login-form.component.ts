import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { LoginState } from '../../../../state/reducer';
import { Store } from '@ngrx/store';
import { loginAction } from '../../../../state/actions';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss'],
})
export class LoginFormComponent {

  loginForm = this.formBuilder.group({
    email : ["",[Validators.required,Validators.email]],
    password : ["",[Validators.required]]
  })
  get email(){ return this.loginForm.get("email")! }
  get password(){ return this.loginForm.get("password")! }

  constructor(private loginStore : Store<LoginState>,private formBuilder : FormBuilder) {}

  login(){
    if(!this.loginForm.valid){
      this.loginForm.markAllAsTouched()
      return;
    }
    const formData = this.loginForm.value;
    this.loginStore.dispatch(loginAction({email : formData.email!,password : formData.password!}))
  }

}
