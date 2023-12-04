import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostLikeButtonComponent } from './post-like-button/post-like-button.component';
import { LikeButtonModule } from '../like-button/like-button.module';
import { StoreModule } from '@ngrx/store';
import { postLikeReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { PostLikeEffect } from './state/effect';



@NgModule({
  declarations: [
    PostLikeButtonComponent
  ],
  imports: [
    CommonModule,
    LikeButtonModule,
    StoreModule.forFeature("PostLikeStore", postLikeReducer),
    EffectsModule.forFeature([PostLikeEffect])
  ],
  exports : [
    PostLikeButtonComponent
  ]
})
export class PostLikeButtonModule { }
