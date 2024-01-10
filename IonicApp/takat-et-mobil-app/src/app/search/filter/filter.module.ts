import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { FilterPageRoutingModule } from './filter-routing.module';

import { FilterPage } from './filter.page';
import { SearchBoxModule } from 'src/app/shareds/search-box/search-box.module';
import { CategorySelectorModule } from 'src/app/shareds/category-selector/category-selector.module';
import { StoreModule } from '@ngrx/store';
import { filterPostsPageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { FilterPostsPageEffect } from './state/effect';
import { AbstractPostListModule } from 'src/app/shareds/abstract-post-list/abstract-post-list.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FilterPageRoutingModule,
    ReactiveFormsModule,
    SearchBoxModule,
    CategorySelectorModule,
    StoreModule.forFeature('FilterPostPageStore',filterPostsPageReducer),
    EffectsModule.forFeature([FilterPostsPageEffect]),
    AbstractPostListModule
  ],
  declarations: [
    FilterPage,
  ]
})
export class FilterPageModule {}
