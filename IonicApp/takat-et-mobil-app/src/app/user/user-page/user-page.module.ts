import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';


import { UserPage } from './user.page';
import { UserInfoModule } from 'src/app/shareds/user-info/user-info.module';
import { StoreModule } from '@ngrx/store';
import { userPageCollectionReducer } from './state/reducer';
import { UserPageRoutingModule } from './user-page-routing.module';
import { ButtonsModule } from 'src/app/shareds/buttons/buttons.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    StoreModule.forFeature("UserPageCollectionStore",userPageCollectionReducer),
    UserPageRoutingModule,
    UserInfoModule,
    ButtonsModule
  ],
  declarations: [UserPage],
})
export class UserPageModule {}
