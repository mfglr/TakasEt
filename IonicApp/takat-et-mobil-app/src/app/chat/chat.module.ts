import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatRoutingModule } from './chat-routing.module';
import { IonicModule } from '@ionic/angular';
import { StoreModule } from '@ngrx/store';
import { chatReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { ChatEffect } from './state/effect';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ChatRoutingModule,
    IonicModule,
    StoreModule.forFeature("ChatStore",chatReducer),
    EffectsModule.forFeature([ChatEffect]),
  ],
})
export class ChatModule { }
