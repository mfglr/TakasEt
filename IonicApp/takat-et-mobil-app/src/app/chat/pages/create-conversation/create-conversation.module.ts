import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreateConversationPageRoutingModule } from './create-conversation-routing.module';

import { CreateConversationPage } from './create-conversation.page';
import { UserItemComponent } from './components/user-item/user-item.component';
import { UserItemListComponent } from './components/user-item-list/user-item-list.component';
import { ProfileImageModule } from 'src/app/shareds/profile-image/profile-image.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CreateConversationPageRoutingModule,
    ProfileImageModule
  ],
  declarations: [
    CreateConversationPage,
    UserItemComponent,
    UserItemListComponent
  ]
})
export class CreateConversationPageModule {}
