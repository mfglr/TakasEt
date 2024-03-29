import { Component, Input } from '@angular/core';
import { MessageStatus } from 'src/app/chat/models/responses/message-response';

@Component({
  selector: 'app-message-state',
  templateUrl: './message-state.component.html',
  styleUrls: ['./message-state.component.scss'],
})
export class MessageStateComponent{

  notCreated = MessageStatus.NotCreated;
  saved = MessageStatus.Created;
  received = MessageStatus.Received;
  viewed = MessageStatus.Viewed;

  @Input() messageState? : MessageStatus;

}
