import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { LoginState } from '../../state/reducer';
import { loginAction } from '../../state/actions';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage{

  loginForm = this.formBuilder.group({
    email : ["",[Validators.required,Validators.email]],
    password : ["",[Validators.required]]
  })
  get email(){ return this.loginForm.get("email")! }
  get password(){ return this.loginForm.get("password")! }

  constructor(
    private loginStore : Store<LoginState>,
    private formBuilder : FormBuilder,
    private loginService : LoginService
  ) {}

  login(){
    if(!this.loginForm.valid){
      this.loginForm.markAllAsTouched()
      return;
    }
    const formData = this.loginForm.value;
    this.loginStore.dispatch(loginAction({email : formData.email!,password : formData.password!}))
  }

  loginByFacebook(){
    this.loginService.loginByFacebook().subscribe();
  }

  isVisible = false;
  changePasswordVisibility = () => this.isVisible = !this.isVisible;
}
