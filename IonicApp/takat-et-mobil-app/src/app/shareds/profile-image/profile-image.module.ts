import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileImageComponent } from './profile-image/profile-image.component';
import { IonicModule } from '@ionic/angular';

@NgModule({
  declarations: [
    ProfileImageComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
  ],
  exports : [ProfileImageComponent]
})
export class ProfileImageModule { }
