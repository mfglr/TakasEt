import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePageRoutingModule } from './home-routing.module';

import { HomePage } from './home.page';
import { PostListModule } from 'src/app/shareds/post-list/post-list.module';
import { StoreModule } from '@ngrx/store';
import { HomePageReducer } from './state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { HomePageEffect } from './state/effect';
import { AddStoryCircleComponent } from './components/add-story-circle/add-story-circle.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    PostListModule,
    StoreModule.forFeature("HomePageStore",HomePageReducer),
    EffectsModule.forFeature([HomePageEffect])
  ],
  declarations: [
    HomePage,
    AddStoryCircleComponent
  ]
})
export class HomePageModule {}
