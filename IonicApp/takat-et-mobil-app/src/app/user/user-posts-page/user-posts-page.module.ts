import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UserPostsPage } from './user-posts.page';
import { UserPostsPageRoutingModule } from './user-posts-page-routing.module';
import { PostListModule } from 'src/app/shareds/post-list/post-list.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    UserPostsPageRoutingModule,
    PostListModule
  ],
  declarations: [UserPostsPage]
})
export class UserPostsPageModule {}
