import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageStateComponent } from './message-state/message-state.component';
import { IonicModule } from '@ionic/angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MessageInputComponent } from './message-input/message-input.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    MessageStateComponent,
    MessageInputComponent
  ],
  imports: [
    CommonModule,
    IonicModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports : [
    MessageStateComponent,MessageInputComponent
  ]
})
export class ChatComponentsModule { }
