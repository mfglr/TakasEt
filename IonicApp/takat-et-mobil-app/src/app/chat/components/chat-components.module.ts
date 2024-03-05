import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageStateComponent } from './message-state/message-state.component';
import { IonicModule } from '@ionic/angular';



@NgModule({
  declarations: [
    MessageStateComponent
  ],
  imports: [
    CommonModule,
    IonicModule
  ],
  exports : [
    MessageStateComponent
  ]
})
export class ChatComponentsModule { }
