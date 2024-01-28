import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ConversationPageRoutingModule } from './conversation-routing.module';

import { ConversationPage } from './conversation.page';
import { ProfileImageModule } from 'src/app/shareds/profile-image/profile-image.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    IonicModule,
    ConversationPageRoutingModule,
    ProfileImageModule
  ],
  declarations: [ConversationPage]
})
export class ConversationPageModule {}
