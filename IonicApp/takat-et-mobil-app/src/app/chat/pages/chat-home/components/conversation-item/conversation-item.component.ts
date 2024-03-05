import { Component, Input } from '@angular/core';
import { ConversationResponse } from '../../models/responses/conversation-response';

@Component({
  selector: 'app-conversation-item',
  templateUrl: './conversation-item.component.html',
  styleUrls: ['./conversation-item.component.scss'],
})
export class ConversationItemComponent{
  @Input() conversation? : ConversationResponse;
}
