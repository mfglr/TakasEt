import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { FollowingPageRoutingModule } from './following-routing.module';

import { FollowingPage } from './following.page';
import { FollowingModule } from 'src/app/shareds/following/following.module';
import { StoreModule } from '@ngrx/store';
import { profileFollowingPageReducer } from './state/reducer';
import { SwiperHeaderModule } from 'src/app/shareds/swiper-header/swiper-header.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FollowingPageRoutingModule,
    FollowingModule,
    StoreModule.forFeature("ProfileFollowingPageStore",profileFollowingPageReducer),
    SwiperHeaderModule
  ],
  declarations: [FollowingPage],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class FollowingPageModule {}
