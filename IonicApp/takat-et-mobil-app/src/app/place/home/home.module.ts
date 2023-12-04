import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePageRoutingModule } from './home-routing.module';

import { HomePage } from './home.page';
import { PostListModule } from 'src/app/shareds/post-list/post-list.module';
import { StoreModule } from '@ngrx/store';
import { homePageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { HomePageEffect } from './state/effect';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    ReactiveFormsModule,
    PostListModule,
    StoreModule.forFeature("HomePageState",homePageReducer),
    EffectsModule.forFeature([HomePageEffect])
  ],
  declarations: [
    HomePage,
  ]
})
export class HomePageModule {}
