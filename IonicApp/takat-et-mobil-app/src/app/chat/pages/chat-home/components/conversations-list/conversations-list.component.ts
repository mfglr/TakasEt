import { Component, Input } from '@angular/core';
import { ConversationState } from 'src/app/chat/state/reducer';

@Component({
  selector: 'app-conversations-list',
  templateUrl: './conversations-list.component.html',
  styleUrls: ['./conversations-list.component.scss'],
})
export class ConversationsListComponent{
  @Input() conversations? : ConversationState[] | null
}
