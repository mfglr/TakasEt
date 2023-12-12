import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UserPageRoutingModule } from './user-routing.module';

import { UserPage } from './user.page';
import { UserInfoModule } from 'src/app/shareds/user-info/user-info.module';
import { StoreModule } from '@ngrx/store';
import { userPageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserPageEffect } from './state/effect';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    StoreModule.forFeature("UserPageStore",userPageReducer),
    EffectsModule.forFeature([UserPageEffect]),
    UserPageRoutingModule,
    UserInfoModule
  ],
  declarations: [UserPage]
})
export class UserPageModule {}
