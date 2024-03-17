import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { first } from 'rxjs';
import { ChatState } from '../../state/reducer';
import { nextPageConversationsAction } from '../../state/actions';
import { selectForChatHomePage, selectIsSynchronized } from '../../state/selectors';

@Component({
  selector: 'app-chat-home',
  templateUrl: './chat-home.page.html',
  styleUrls: ['./chat-home.page.scss'],
})
export class ChatHomePage implements OnInit {

  constructor(private readonly chatStore : Store<ChatState>) { }
  conversationsList$ = this.chatStore.select(selectForChatHomePage);

  ngOnInit() {
    this.conversationsList$.pipe(first()).subscribe(x => {
      if(x.length == 0){
        this.chatStore.dispatch(nextPageConversationsAction())
      }
    })
  }

}
