import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SwiperHeaderComponent } from './swiper-header/swiper-header.component';
import { IonicModule } from '@ionic/angular';



@NgModule({
  declarations: [
    SwiperHeaderComponent,
  ],
  imports: [
    CommonModule,IonicModule
  ],
  exports : [
    SwiperHeaderComponent
  ]
})
export class SwiperHeaderModule { }
