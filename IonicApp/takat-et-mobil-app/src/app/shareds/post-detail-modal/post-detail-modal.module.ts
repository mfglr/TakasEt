import {  NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostDetailModalComponent } from './post-detail-modal/post-detail-modal.component';
import { IonicModule } from '@ionic/angular';
import { PostImageSliderModule } from '../post-image-slider/post-image-slider.module';
import { ProfileImageModule } from '../profile-image/profile-image.module';
import { PipesModule } from 'src/app/pipes/pipes.module';

@NgModule({
  declarations: [
    PostDetailModalComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    PostImageSliderModule,
    ProfileImageModule,
    PipesModule
  ],
  exports : [
    PostDetailModalComponent
  ]
})
export class PostDetailModalModule { }
