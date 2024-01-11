import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SearchMessagePageRoutingModule } from './search-message-routing.module';

import { SearchMessagePage } from './search-message.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SearchMessagePageRoutingModule
  ],
  declarations: [SearchMessagePage]
})
export class SearchMessagePageModule {}
