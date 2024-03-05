import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ChatHomePageRoutingModule } from './chat-home-routing.module';

import { ChatHomePage } from './chat-home.page';
import { StoreModule } from '@ngrx/store';
import { chatHomePageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { ChatHomePageEffect } from './state/effect';
import { ConversationItemComponent } from './components/conversation-item/conversation-item.component';
import { ConversationsListComponent } from './components/conversations-list/conversations-list.component';
import { ProfileImageModule } from 'src/app/shareds/profile-image/profile-image.module';
import { PipesModule } from 'src/app/pipes/pipes.module';
import { ChatComponentsModule } from '../../components/chat-components.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ChatHomePageRoutingModule,
    ChatComponentsModule,
    StoreModule.forFeature("ChatHomePageStore",chatHomePageReducer),
    EffectsModule.forFeature([ChatHomePageEffect]),
    ProfileImageModule,
    PipesModule,

  ],
  declarations: [
    ChatHomePage,
    ConversationItemComponent,
    ConversationsListComponent,
  ]
})
export class ChatHomePageModule {}
