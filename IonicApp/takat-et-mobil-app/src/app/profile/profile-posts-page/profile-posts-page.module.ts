import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProfilePostsPageRoutingModule } from './profile-posts-page-routing.module';

import { ProfilePostsPage } from './profile-posts.page';
import { PostListModule } from 'src/app/shareds/post-list/post-list.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProfilePostsPageRoutingModule,
    PostListModule
  ],
  declarations: [ProfilePostsPage]
})
export class ProfilePostsPageModule {}
