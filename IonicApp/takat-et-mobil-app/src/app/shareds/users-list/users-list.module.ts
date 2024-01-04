import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { UsersListComponent } from './users-list/users-list.component';
import { UserItemComponent } from './user-item/user-item.component';
import { ProfileImageModule } from '../profile-image/profile-image.module';
import { PipesModule } from 'src/app/pipes/pipes.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    UsersListComponent,
    UserItemComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    ProfileImageModule,
    PipesModule,
    RouterModule
  ],
  exports : [
    UsersListComponent,
  ]
})
export class UsersListModule { }
