import { Component, Input } from '@angular/core';
import { ConversationResponse } from '../../models/responses/conversation-response';
import { LoginState } from 'src/app/account/state/reducer';
import { Store } from '@ngrx/store';
import { selectUserId } from 'src/app/account/state/selectors';
import { map } from 'rxjs';

@Component({
  selector: 'app-conversation-item',
  templateUrl: './conversation-item.component.html',
  styleUrls: ['./conversation-item.component.scss'],
})
export class ConversationItemComponent{

  @Input() conversation? : ConversationResponse;

  lastMessageStateVisibility$ = this.loginStore.select(selectUserId).pipe(
    map(x => this.conversation && this.conversation.lastMessage && this.conversation.lastMessage.senderId == x)
  )

  constructor(private readonly loginStore : Store<LoginState>) {}



}
