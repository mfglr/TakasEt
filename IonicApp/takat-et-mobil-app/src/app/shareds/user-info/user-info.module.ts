import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { UserInfoHeaderComponent } from './user-info-header/user-info-header.component';
import { ProfileImageModule } from '../profile-image/profile-image.module';
import { AbstractPostListModule } from '../abstract-post-list/abstract-post-list.module';
import { UserInfoContentComponent } from './user-info-content/user-info-content.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    UserInfoHeaderComponent,
    UserInfoContentComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    RouterModule,
    ProfileImageModule,
    AbstractPostListModule
  ],
  exports : [
    UserInfoHeaderComponent,
    UserInfoContentComponent
  ],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class UserInfoModule { }
