import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { profileModuleReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { ProfileModuleEffect } from './state/effect';
import { ProfilePageModule } from './profile-page/profile-page.module';
import { ProfilePostsPageModule } from './profile-posts-page/profile-posts-page.module';
import { ProfileRoutingModule } from './profile-routing-module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ProfilePageModule,
    ProfilePostsPageModule,
    ProfileRoutingModule,
    StoreModule.forFeature("ProfileModuleStore",profileModuleReducer),
    EffectsModule.forFeature([ProfileModuleEffect])
  ]
})
export class ProfileModule { }
