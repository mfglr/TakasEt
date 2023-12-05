import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostListComponent } from './post-list/post-list.component';
import { PostDetailModalModule } from '../post-detail-modal/post-detail-modal.module';
import { PipesModule } from 'src/app/pipes/pipes.module';
import { PostComponent } from './post/post.component';
import { IonicModule } from '@ionic/angular';
import { PostLikeButtonModule } from '../post-like-button/post-like-button.module';
import { ProfileImageModule } from '../profile-image/profile-image.module';
import { StoreModule } from '@ngrx/store';
import { reducer } from './state/reducer';
import { PostImageModule } from '../post-image/post-image.module';

@NgModule({
  declarations: [
    PostListComponent,
    PostComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    PipesModule,
    StoreModule.forFeature("PostListStore",reducer),
    PostDetailModalModule,
    ProfileImageModule,
    PostLikeButtonModule,
    PostDetailModalModule,
    PostImageModule
  ],
  exports : [
    PostListComponent
  ]
})
export class PostListModule { }
