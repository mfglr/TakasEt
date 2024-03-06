import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { first } from 'rxjs';
import { Chat } from '../../state/reducer';
import { nextPageConversationsAction } from '../../state/actions';
import { selectConversationResponses } from '../../state/selectors';

@Component({
  selector: 'app-chat-home',
  templateUrl: './chat-home.page.html',
  styleUrls: ['./chat-home.page.scss'],
})
export class ChatHomePage implements OnInit {

  constructor(
    private readonly chatStore : Store<Chat>,
  ) { }

  conversations$ = this.chatStore.select(selectConversationResponses);

  ngOnInit() {
    this.conversations$.pipe(first()).subscribe(x => {
      if(x.length == 0){
        this.chatStore.dispatch(nextPageConversationsAction())
      }
    })
  }

}
