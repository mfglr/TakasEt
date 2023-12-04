import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostImageSliderComponent } from './post-image-slider/post-image-slider.component';
import { StoreModule } from '@ngrx/store';
import { postImageSliderReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { PostImageSliderEffect } from './state/effect';
@NgModule({
  declarations: [
    PostImageSliderComponent
  ],
  imports: [
    CommonModule,
    StoreModule.forFeature("PostImageSliderStore",postImageSliderReducer),
    EffectsModule.forFeature([PostImageSliderEffect]),
  ],
  exports : [
    PostImageSliderComponent
  ],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class PostImageSliderModule { }
