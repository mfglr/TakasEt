import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { ProfilePageModule } from './profile-page/profile-page.module';
import { ProfilePostsPageModule } from './profile-posts-page/profile-posts-page.module';
import { ProfileRoutingModule } from './profile-routing-module';
import { FollowingPageModule } from './following/following.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ProfilePageModule,
    ProfilePostsPageModule,
    FollowingPageModule,
    ProfileRoutingModule,
  ]
})
export class ProfileModule { }
