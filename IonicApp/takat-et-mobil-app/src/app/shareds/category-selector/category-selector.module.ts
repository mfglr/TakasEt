import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { CategorySelectorComponent } from './category-selector/category-selector.component';



@NgModule({
  declarations: [
    CategorySelectorComponent
  ],
  imports: [
    CommonModule,
    IonicModule
  ],
  exports : [ CategorySelectorComponent ]
})
export class CategorySelectorModule { }
