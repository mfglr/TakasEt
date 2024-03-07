import { Component, Input, OnInit } from '@angular/core';
import { ConversationResponse } from '../../../../models/responses/conversation-response';
import { LoginState } from 'src/app/account/state/reducer';
import { Store } from '@ngrx/store';
import { selectUserId } from 'src/app/account/state/selectors';
import { Observable } from 'rxjs';
import { Chat } from 'src/app/chat/state/reducer';
import { selectCountOfNewMessages, selectLastMessage } from 'src/app/chat/state/selectors';
import { MessageResponse } from 'src/app/chat/models/responses/message-response';

@Component({
  selector: 'app-conversation-item',
  templateUrl: './conversation-item.component.html',
  styleUrls: ['./conversation-item.component.scss'],
})
export class ConversationItemComponent implements OnInit{

  @Input() conversation? : ConversationResponse;
  loginUserId = this.loginStore.select(selectUserId);
  lastMessage$? : Observable<MessageResponse>;
  countOfNewMessages$? : Observable<number>;

  constructor(
    private readonly loginStore : Store<LoginState>,
    private readonly chatStore : Store<Chat>
  ) {}

  ngOnInit(): void {
    if(this.conversation){
      this.countOfNewMessages$ = this.chatStore.select(selectCountOfNewMessages({receiverId : this.conversation.receiverId}));
      this.lastMessage$ = this.chatStore.select(selectLastMessage({receiverId : this.conversation.receiverId}));
    }
  }

}
