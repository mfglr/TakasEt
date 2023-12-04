import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileImageComponent } from './profile-image/profile-image.component';
import { IonicModule } from '@ionic/angular';
import { StoreModule } from '@ngrx/store';
import { profileImageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { ProfileImageEffect } from './state/effect';

@NgModule({
  declarations: [
    ProfileImageComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    StoreModule.forFeature("ProfileImageStore",profileImageReducer),
    EffectsModule.forFeature([ProfileImageEffect])
  ],
  exports : [ProfileImageComponent]
})
export class ProfileImageModule { }
