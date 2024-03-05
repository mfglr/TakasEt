import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ConversationPageRoutingModule } from './conversation-routing.module';

import { ConversationPage } from './conversation.page';
import { MessageInputComponent } from './components/message-input/message-input.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { conversationPageReducer } from './state/reducer';
import { ConversationPageEffect } from './state/effect';
import { PipesModule } from 'src/app/pipes/pipes.module';
import { ProfileImageModule } from 'src/app/shareds/profile-image/profile-image.module';
import { MessageBoxComponent } from './components/message-box/message-box.component';
import { MessageBoxListComponent } from './components/message-box-list/message-box-list.component';
import { ChatComponentsModule } from '../../components/chat-components.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    ConversationPageRoutingModule,
    PipesModule,
    ProfileImageModule,
    ChatComponentsModule,
    StoreModule.forFeature("ConversationPageStore",conversationPageReducer),
    EffectsModule.forFeature([ConversationPageEffect])
  ],
  declarations: [
    ConversationPage,
    MessageInputComponent,
    MessageBoxComponent,
    MessageBoxListComponent
  ]
})
export class ConversationPageModule {}