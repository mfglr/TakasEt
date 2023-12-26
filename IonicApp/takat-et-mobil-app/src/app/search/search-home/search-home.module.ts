import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SearchHomePageRoutingModule } from './search-home-routing.module';

import { SearchHomePage } from './search-home.page';
import { AbstractPostListModule } from 'src/app/shareds/abstract-post-list/abstract-post-list.module';
import { StoreModule } from '@ngrx/store';
import { searchHomePageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { SearchHomePageEffect } from './state/effect';
import { SearchInputComponent } from './search-input/search-input.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ReactiveFormsModule,
    SearchHomePageRoutingModule,
    StoreModule.forFeature("SearchHomePageStore",searchHomePageReducer),
    EffectsModule.forFeature([SearchHomePageEffect]),
    AbstractPostListModule,
  ],
  declarations: [
    SearchHomePage,
    SearchInputComponent
  ]
})
export class SearchHomePageModule {}
