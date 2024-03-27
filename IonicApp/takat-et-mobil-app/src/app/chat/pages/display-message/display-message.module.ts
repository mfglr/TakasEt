import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { DisplayMessagePageRoutingModule } from './display-message-routing.module';

import { DisplayMessagePage } from './display-message.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    DisplayMessagePageRoutingModule
  ],
  declarations: [DisplayMessagePage],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class DisplayMessagePageModule {}
