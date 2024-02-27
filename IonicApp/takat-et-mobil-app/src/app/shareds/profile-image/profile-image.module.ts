import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileImageComponent } from './profile-image/profile-image.component';
import { IonicModule } from '@ionic/angular';
import { StoreModule } from '@ngrx/store';
import { userImageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { UserImageEffect } from './state/effect';

@NgModule({
  declarations: [
    ProfileImageComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    StoreModule.forFeature("UserImageStore",userImageReducer),
    EffectsModule.forFeature([UserImageEffect])
  ],
  exports : [ProfileImageComponent]
})
export class ProfileImageModule { }
