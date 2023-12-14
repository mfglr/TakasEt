import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CategoryPageRoutingModule } from './category-routing.module';

import { CategoryPage } from './category.page';
import { PostListModule } from 'src/app/post-list/post-list.module';
import { StoreModule } from '@ngrx/store';
import { CategoryPageCollectionReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { CategoryPageCollectionEffect } from './state/effect';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CategoryPageRoutingModule,
    PostListModule,
    StoreModule.forFeature("CategoryPageCollectionStore",CategoryPageCollectionReducer),
    EffectsModule.forFeature([CategoryPageCollectionEffect])
  ],
  declarations: [CategoryPage]
})
export class CategoryPageModule {}
