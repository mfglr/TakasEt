import {  NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostDetailModalComponent } from './post-detail-modal/post-detail-modal.component';
import { IonicModule } from '@ionic/angular';
import { ProfileImageModule } from '../profile-image/profile-image.module';
import { PipesModule } from 'src/app/pipes/pipes.module';
import { PostImageModule } from '../post-image/post-image.module';

@NgModule({
  declarations: [
    PostDetailModalComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    ProfileImageModule,
    PipesModule,
    PostImageModule
  ],
  exports : [
    PostDetailModalComponent
  ]
})
export class PostDetailModalModule { }
