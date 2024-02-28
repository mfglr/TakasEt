import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { CreateConversationPageRoutingModule } from './create-conversation-routing.module';

import { CreateConversationPage } from './create-conversation.page';
import { UserItemComponent } from './components/user-item/user-item.component';
import { UserItemListComponent } from './components/user-item-list/user-item-list.component';
import { ProfileImageModule } from 'src/app/shareds/profile-image/profile-image.module';
import { StoreModule } from '@ngrx/store';
import { CreateConversationPageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { CreateConversationPageEffect } from './state/effect';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    CreateConversationPageRoutingModule,
    ProfileImageModule,
    StoreModule.forFeature("CreateConversationPageStore",CreateConversationPageReducer),
    EffectsModule.forFeature([CreateConversationPageEffect])
  ],
  declarations: [
    CreateConversationPage,
    UserItemComponent,
    UserItemListComponent
  ]
})
export class CreateConversationPageModule {}
