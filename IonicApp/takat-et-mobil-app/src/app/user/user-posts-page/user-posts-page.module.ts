import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { UserPostsPage } from './user-posts.page';
import { PostListModule } from 'src/app/post-list/post-list.module';
import { UserPostsPageRoutingModule } from './user-posts-page-routing.module';

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
