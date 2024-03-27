import { Component, Input, QueryList, ViewChildren } from '@angular/core';
import { MessageState } from 'src/app/chat/state/reducer';

@Component({
  selector: 'app-message-box-list',
  templateUrl: './message-box-list.component.html',
  styleUrls: ['./message-box-list.component.scss'],
})
export class MessageBoxListComponent{
  @Input() messages? : MessageState[] | null;
}
