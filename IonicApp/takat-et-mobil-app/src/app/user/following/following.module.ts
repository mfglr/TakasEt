import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { FollowingPageRoutingModule } from './following-routing.module';

import { FollowingPage } from './following.page';
import { ProfileImageModule } from 'src/app/shareds/profile-image/profile-image.module';
import { UserItemComponent } from './user-item/user-item.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FollowingPageRoutingModule,
    ProfileImageModule
  ],
  declarations: [
    FollowingPage,
    UserItemComponent
  ]
})
export class FollowingPageModule {}
