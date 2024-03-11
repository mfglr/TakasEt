import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { MessageState, UserState } from 'src/app/chat/state/reducer';

@Component({
  selector: 'app-conversation-item',
  templateUrl: './conversation-item.component.html',
  styleUrls: ['./conversation-item.component.scss'],
})
export class ConversationItemComponent{
  @Input() conversationItem? : {userState? : UserState, countOfUnviewedMessages : number, lastMessage : MessageState}
  loginUserId$ = this.loginStore.select(selectUserId);
  constructor(private loginStore : Store<LoginState>) {}
}
