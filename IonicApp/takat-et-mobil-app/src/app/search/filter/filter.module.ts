import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { FilterPageRoutingModule } from './filter-routing.module';

import { FilterPage } from './filter.page';
import { SearchBoxModule } from 'src/app/shareds/search-box/search-box.module';
import { CategorySelectorModule } from 'src/app/shareds/category-selector/category-selector.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FilterPageRoutingModule,
    ReactiveFormsModule,
    SearchBoxModule,
    CategorySelectorModule
  ],
  declarations: [
    FilterPage,
  ]
})
export class FilterPageModule {}
