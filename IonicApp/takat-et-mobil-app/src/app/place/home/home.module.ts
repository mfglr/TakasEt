import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePageRoutingModule } from './home-routing.module';

import { HomePage } from './home.page';
import { StoreModule } from '@ngrx/store';
import { homePageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { HomePageEffect } from './state/effect';
import { PostListModule } from 'src/app/post-list/post-list.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    ReactiveFormsModule,
    PostListModule,
    StoreModule.forFeature("HomePageStore",homePageReducer),
    EffectsModule.forFeature([HomePageEffect])
  ],
  declarations: [
    HomePage,
  ]
})
export class HomePageModule {}
