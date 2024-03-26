import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageStateComponent } from './message-state/message-state.component';
import { IonicModule } from '@ionic/angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MessageStateComponent,
  ],
  imports: [
    CommonModule,
    IonicModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports : [
    MessageStateComponent
  ]
})
export class ChatComponentsModule { }
