import { Component, Input } from '@angular/core';
import { MessageState, UserState } from 'src/app/chat/state/reducer';

@Component({
  selector: 'app-conversations-list',
  templateUrl: './conversations-list.component.html',
  styleUrls: ['./conversations-list.component.scss'],
})
export class ConversationsListComponent{
  @Input() conversationList? : {
    userState? : UserState,
    countOfUnviewedMessages : number,
    lastMessage : MessageState
  }[] | null
}
