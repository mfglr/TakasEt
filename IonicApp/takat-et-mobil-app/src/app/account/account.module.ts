import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account-routing.module';
import { loginReducer } from './state/reducer';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { LoginEffect } from './state/effect';
import { IonicModule } from '@ionic/angular';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AccountRoutingModule,
    IonicModule,
    ReactiveFormsModule,
    StoreModule.forFeature("LoginStore",loginReducer),
    EffectsModule.forFeature([LoginEffect])
  ]
})
export class AccountModule { }
