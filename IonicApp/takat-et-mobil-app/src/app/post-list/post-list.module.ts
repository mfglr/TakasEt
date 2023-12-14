import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { PostComponent } from './post/post.component';
import { PostListComponent } from './post-list/post-list.component';
import { PostDetailModalComponent } from './post-detail-modal/post-detail-modal.component';
import { ProfileImageModule } from '../shareds/profile-image/profile-image.module';
import { RouterModule } from '@angular/router';
import { PostImageSliderComponent } from './post-image-slider/post-image-slider.component';
import { PostImageSliderItemComponent } from './post-image-slider-item/post-image-slider-item.component';
import { PostLikeButtonModule } from '../shareds/post-like-button/post-like-button.module';
import { PipesModule } from '../pipes/pipes.module';
import { StoreModule } from '@ngrx/store';
import { postListReducer } from './state/reducer';

@NgModule({
  declarations: [
    PostComponent,
    PostListComponent,
    PostDetailModalComponent,
    PostImageSliderComponent,
    PostImageSliderItemComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    RouterModule,
    ProfileImageModule,
    PostLikeButtonModule,
    PipesModule,
    StoreModule.forFeature("PostListStore",postListReducer)
  ],
  exports : [ PostListComponent ],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class PostListModule { }
