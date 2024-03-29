import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AddPhotosPageRoutingModule } from './add-photos-routing.module';

import { AddPhotosPage } from './add-photos.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AddPhotosPageRoutingModule,
    ReactiveFormsModule

  ],
  declarations: [AddPhotosPage],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AddPhotosPageModule {}
