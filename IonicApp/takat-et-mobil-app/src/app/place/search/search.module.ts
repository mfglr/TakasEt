import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SearchPageRoutingModule } from './search-routing.module';

import { SearchPage } from './search.page';
import { StoreModule } from '@ngrx/store';
import { searchPageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { SearchPageEffect } from './state/effect';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SearchPageRoutingModule,
    StoreModule.forFeature("SearchPageStore",searchPageReducer),
    EffectsModule.forFeature([SearchPageEffect])
  ],
  declarations: [SearchPage]
})
export class SearchPageModule {}
