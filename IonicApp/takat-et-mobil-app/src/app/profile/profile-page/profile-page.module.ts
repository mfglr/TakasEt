import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProfilePageRoutingModule } from './profile-page-routing.module';

import { ProfilePage } from './profile.page';
import { StoreModule } from '@ngrx/store';
import { profilePageReducer } from './state/reducer';
import { UserInfoModule } from 'src/app/shareds/user-info/user-info.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProfilePageRoutingModule,
    StoreModule.forFeature("ProfilePageStore",profilePageReducer),
    UserInfoModule
  ],
  declarations: [ProfilePage]
})
export class ProfilePageModule {}
