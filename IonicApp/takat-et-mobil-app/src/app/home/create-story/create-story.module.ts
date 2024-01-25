import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { CreateStoryPageRoutingModule } from './create-story-routing.module';

import { CreateStoryPage } from './create-story.page';
import { AddStorySliderComponent } from './components/add-story-slider/add-story-slider.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    CreateStoryPageRoutingModule
  ],
  declarations: [
    CreateStoryPage,
    AddStorySliderComponent
  ],
  schemas : [CUSTOM_ELEMENTS_SCHEMA]
})
export class CreateStoryPageModule {}
