import { Component, Input } from '@angular/core';
import { MessageState } from 'src/app/models/responses/message-response';

@Component({
  selector: 'app-message-state',
  templateUrl: './message-state.component.html',
  styleUrls: ['./message-state.component.scss'],
})
export class MessageStateComponent{

  notSaved = MessageState.NotSaved;
  saved = MessageState.Saved;
  received = MessageState.Received;
  viewed = MessageState.Viewed;

  @Input() messageState? : MessageState;

}
