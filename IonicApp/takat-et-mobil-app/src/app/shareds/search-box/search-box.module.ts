import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { SearchBoxComponent } from './search-box/search-box.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    SearchBoxComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    ReactiveFormsModule
  ],
  exports : [
    SearchBoxComponent
  ]
})
export class SearchBoxModule { }
