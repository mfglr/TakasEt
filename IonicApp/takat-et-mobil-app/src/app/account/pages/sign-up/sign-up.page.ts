import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { matchPasswordsValidator } from 'src/app/Validators/MatchPasswordsValidator';
import { SignUpByEmail } from '../../models/requests/sign-up-by-email';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { LoginState } from '../../state/reducer';
import { signUpByEmailAction } from '../../state/actions';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.page.html',
  styleUrls: ['./sign-up.page.scss'],
})
export class SignUpPage{


  signUpForm = this.formBuilder.group(
    {
      email : ["",[Validators.email,Validators.required]],
      password : ["",[Validators.required,Validators.minLength(9)]],
      confirmPassword : [""],
    },
    { validators : [matchPasswordsValidator()]}
  )

  get email(){ return this.signUpForm.get("email")!}
  get password() { return this.signUpForm.get("password")!}
  get confirmPassword() {return this.signUpForm.get("confirmPassword")!}

  constructor(
    private formBuilder : FormBuilder,
    private readonly loginStore : Store<LoginState>,
    private router : Router
  ) { }

  signUp(){
    if(this.signUpForm.valid)
      this.loginStore.dispatch(signUpByEmailAction({request: this.signUpForm.value as SignUpByEmail}))
    else
      this.signUpForm.markAllAsTouched();
  }

  isVisible = false;
  changePasswordVisibility = () => this.isVisible = !this.isVisible;

}
