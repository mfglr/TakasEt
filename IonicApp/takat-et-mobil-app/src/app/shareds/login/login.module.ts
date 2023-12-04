import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { loginReducer } from './login_state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { LoginEffect } from './login_state/effect';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    StoreModule.forFeature("LoginState",loginReducer),
    EffectsModule.forFeature([LoginEffect]),
  ],
  exports : [
    LoginComponent
  ]
})
export class LoginModule { }
