import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { UserResponse } from 'src/app/models/responses/user-response';
import { State } from './state/reducer';
import { initPageAction, nextPageMessagesAction } from './state/actions';
import { MessageResponse } from 'src/app/models/responses/message-response';
import { selectMessageResponses } from './state/selectors';
import { Observable, first } from 'rxjs';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit {
  user : UserResponse | null;

  constructor(
    private readonly router : Router,
    private readonly store : Store<State>,
  ) {
    this.user = this.router.getCurrentNavigation()?.extras.state as (UserResponse | null)
  }

  messages$? : Observable<MessageResponse[]>;

  ngOnInit() {

    if(this.user){
      this.store.dispatch(initPageAction({userId : this.user.id}));

      this.messages$ = this.store.select(selectMessageResponses({userId : this.user.id}));

      this.messages$.pipe(first()).subscribe(
        x => {
          if(x.length == 0)
            this.store.dispatch(nextPageMessagesAction({userId : this.user!.id}))
        }
      )

    }


  }



}
