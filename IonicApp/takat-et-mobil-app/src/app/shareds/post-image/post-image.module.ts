import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostImageSliderComponent } from './post-image-slider/post-image-slider.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { PostImageSliderItemComponent } from './post-image-slider-item/post-image-slider-item.component';
import { IonicModule } from '@ionic/angular';

@NgModule({
  declarations: [
    PostImageSliderComponent,
    PostImageSliderItemComponent,
  ],
  imports: [
    CommonModule,
    IonicModule,
  ],
  exports : [
    PostImageSliderComponent
  ],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class PostImageModule { }
