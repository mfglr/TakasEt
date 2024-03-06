import { Component, Input } from '@angular/core';
import { MessageResponse } from 'src/app/chat/models/responses/message-response';

@Component({
  selector: 'app-message-box-list',
  templateUrl: './message-box-list.component.html',
  styleUrls: ['./message-box-list.component.scss'],
})
export class MessageBoxListComponent{
  @Input() messages? : MessageResponse[] | null;
}
