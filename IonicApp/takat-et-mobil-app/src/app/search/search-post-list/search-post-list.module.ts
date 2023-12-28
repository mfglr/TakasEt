import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SearchPostListPageRoutingModule } from './search-post-list-routing.module';

import { SearchPostListPage } from './search-post-list.page';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { entitySearcPostListPageReducer } from './state/reducer';
import { EntitySearchPostListPageEffect } from './state/effect';
import { PostListModule } from 'src/app/post-list/post-list.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SearchPostListPageRoutingModule,
    StoreModule.forFeature("EntitySearchPostListPageStore",entitySearcPostListPageReducer),
    EffectsModule.forFeature([EntitySearchPostListPageEffect]),
    PostListModule
  ],
  declarations: [SearchPostListPage]
})
export class SearchPostListPageModule {}
