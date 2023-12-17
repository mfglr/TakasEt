import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FollowButtonComponent } from './follow-button/follow-button.component';
import { IonicModule } from '@ionic/angular';



@NgModule({
  declarations: [
    FollowButtonComponent
  ],
  imports: [
    CommonModule,
    IonicModule
  ],
  exports: [
    FollowButtonComponent
  ]
})
export class ButtonsModule { }
