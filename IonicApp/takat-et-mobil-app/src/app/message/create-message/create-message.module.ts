import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreateMessagePageRoutingModule } from './create-message-routing.module';

import { CreateMessagePage } from './create-message.page';
import { StoreModule } from '@ngrx/store';
import { createMessagePageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { CreateMessagePageEffect } from './state/effect';
import { CreateMessageItemComponent } from './components/create-message-item/create-message-item.component';
import { ProfileImageModule } from 'src/app/shareds/profile-image/profile-image.module';
import { PipesModule } from 'src/app/pipes/pipes.module';
import { CreateMessageListComponent } from './components/create-message-list/create-message-list.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CreateMessagePageRoutingModule,
    ProfileImageModule,
    PipesModule,
    StoreModule.forFeature("CreateMessagePageStore",createMessagePageReducer),
    EffectsModule.forFeature([CreateMessagePageEffect]),
  ],
  declarations: [
    CreateMessagePage,
    CreateMessageItemComponent,
    CreateMessageListComponent
  ]
})
export class CreateMessagePageModule {}
