import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, first } from 'rxjs';
import { nextPageUsersAction } from '../../state/actions';
import { ChatState, UserState } from '../../state/reducer';
import { selectUsers } from '../../state/selectors';

@Component({
  selector: 'app-create-conversation',
  templateUrl: './create-conversation.page.html',
  styleUrls: ['./create-conversation.page.scss'],
})
export class CreateConversationPage implements OnInit {

  constructor(private readonly chatStore : Store<ChatState> ) { }

  users$ : Observable<UserState[]> = this.chatStore.select(selectUsers)

  ngOnInit() {

    this.users$.pipe(first()).subscribe(x => {
      if(x.length == 0)
        this.chatStore.dispatch(nextPageUsersAction())
    })
  }


}
