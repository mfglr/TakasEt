import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { loadConversationUserAction } from 'src/app/chat/state/actions';
import { ChatState, MessageState, UserState } from 'src/app/chat/state/reducer';

@Component({
  selector: 'app-conversation-item',
  templateUrl: './conversation-item.component.html',
  styleUrls: ['./conversation-item.component.scss'],
})
export class ConversationItemComponent{
  @Input() conversationItem? : {
    userId : string,
    userState? : UserState,
    countOfUnviewedMessages : number,
    lastMessage : MessageState | undefined
  }
  loginUserId$ = this.loginStore.select(selectUserId);
  constructor(
    private readonly loginStore : Store<LoginState>,
    private readonly chatStore : Store<ChatState>
  ) {}

  ngOnChanges(){
    if(this.conversationItem && !this.conversationItem.userState){
      this.chatStore.dispatch(loadConversationUserAction({userId : this.conversationItem.userId}))
    }
  }



}
