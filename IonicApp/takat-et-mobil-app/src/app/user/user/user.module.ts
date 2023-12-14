import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UserPageRoutingModule } from './user-routing.module';

import { UserPage } from './user.page';
import { UserInfoModule } from 'src/app/shareds/user-info/user-info.module';
import { StoreModule } from '@ngrx/store';
import { userPageCollectionReducer } from './state/reducer';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    StoreModule.forFeature("UserPageCollectionStore",userPageCollectionReducer),
    UserPageRoutingModule,
    UserInfoModule
  ],
  declarations: [UserPage],
})
export class UserPageModule {}
