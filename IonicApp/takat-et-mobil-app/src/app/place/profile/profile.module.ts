import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProfilePageRoutingModule } from './profile-routing.module';

import { ProfilePage } from './profile.page';
import { ProfileImageModule } from 'src/app/shareds/profile-image/profile-image.module';
import { PipesModule } from 'src/app/pipes/pipes.module';
import { AbstractPostListModule } from 'src/app/shareds/abstract-post-list/abstract-post-list.module';
import { StoreModule } from '@ngrx/store';
import { profilePageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { ProfilePageEffect } from './state/effect';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProfilePageRoutingModule,
    ProfileImageModule,
    PipesModule,
    AbstractPostListModule,
    StoreModule.forFeature("ProfilePageStore",profilePageReducer),
    EffectsModule.forFeature([ProfilePageEffect])
  ],
  declarations: [ProfilePage],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class ProfilePageModule {}
