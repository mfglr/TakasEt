import { Component, Input } from '@angular/core';
import { ConversationResponse } from '../../../../models/responses/conversation-response';

@Component({
  selector: 'app-conversations-list',
  templateUrl: './conversations-list.component.html',
  styleUrls: ['./conversations-list.component.scss'],
})
export class ConversationsListComponent{
  @Input() conversations? : ConversationResponse[] | null
}
