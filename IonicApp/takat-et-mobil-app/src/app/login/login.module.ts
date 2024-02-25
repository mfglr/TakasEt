import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { loginReducer } from './state/reducer';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { LoginEffect } from './state/effect';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LoginRoutingModule,
    StoreModule.forFeature("LoginStore",loginReducer),
    EffectsModule.forFeature([LoginEffect])
  ]
})
export class LoginModule { }
