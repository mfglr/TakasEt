import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { UsersListComponent } from './users-list/users-list.component';
import { UserItemComponent } from './user-item/user-item.component';

@NgModule({
  declarations: [
    UsersListComponent,
    UserItemComponent
  ],
  imports: [
    CommonModule,
    IonicModule
  ],
  exports : [
    UsersListComponent
  ]
})
export class UsersListModule { }
