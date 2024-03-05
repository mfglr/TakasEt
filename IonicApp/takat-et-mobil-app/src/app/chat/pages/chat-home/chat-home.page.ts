import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ChatHomePageState } from './state/reducer';
import { selectConversationResponses, selectConversations } from './state/selectors';
import { first } from 'rxjs';
import { nextPageConversationsAction } from './state/actions';

@Component({
  selector: 'app-chat-home',
  templateUrl: './chat-home.page.html',
  styleUrls: ['./chat-home.page.scss'],
})
export class ChatHomePage implements OnInit {

  constructor(
    private chatHomePageStore : Store<ChatHomePageState>
  ) { }

  conversations$ = this.chatHomePageStore.select(selectConversationResponses);

  ngOnInit() {
    this.conversations$.pipe(first()).subscribe(x => {
      if(x.length == 0)
        this.chatHomePageStore.dispatch(nextPageConversationsAction())
    })
  }

}
