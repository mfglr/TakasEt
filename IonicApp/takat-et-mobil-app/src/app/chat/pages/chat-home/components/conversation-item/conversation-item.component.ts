import { Component, Input, OnInit } from '@angular/core';
import { LoginState } from 'src/app/account/state/reducer';
import { Store } from '@ngrx/store';
import { selectUserId } from 'src/app/account/state/selectors';
import { Observable } from 'rxjs';
import { ChatState, ConversationState, MessageState } from 'src/app/chat/state/reducer';
import { selectCountOfNewMessages, selectLastMessageState } from 'src/app/chat/state/selectors';

@Component({
  selector: 'app-conversation-item',
  templateUrl: './conversation-item.component.html',
  styleUrls: ['./conversation-item.component.scss'],
})
export class ConversationItemComponent implements OnInit{

  @Input() conversation? : ConversationState;
  loginUserId = this.loginStore.select(selectUserId);
  lastMessage$? : Observable<MessageState>;
  countOfNewMessages$? : Observable<number>;

  constructor(
    private readonly loginStore : Store<LoginState>,
    private readonly chatStore : Store<ChatState>
  ) {}

  ngOnInit(): void {
    if(this.conversation){
      this.countOfNewMessages$ = this.chatStore.select(selectCountOfNewMessages({userId : this.conversation.userId}));
      this.lastMessage$ = this.chatStore.select(selectLastMessageState({userId : this.conversation.userId}));
    }
  }

}
