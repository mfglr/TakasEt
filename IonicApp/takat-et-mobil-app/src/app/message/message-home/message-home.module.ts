import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MessageHomePageRoutingModule } from './message-home-routing.module';

import { MessageHomePage } from './message-home.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MessageHomePageRoutingModule
  ],
  declarations: [MessageHomePage]
})
export class MessageHomePageModule {}
