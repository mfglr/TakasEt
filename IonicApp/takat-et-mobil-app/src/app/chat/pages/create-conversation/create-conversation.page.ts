import { Component, OnInit } from '@angular/core';
import { CreateConversationPageState } from './state/reducer';
import { Store } from '@ngrx/store';
import { Observable, first } from 'rxjs';
import { UserResponse } from 'src/app/models/responses/user-response';
import { selectUserResponses } from './state/selectors';
import { nextPageUsersAction } from './state/actions';

@Component({
  selector: 'app-create-conversation',
  templateUrl: './create-conversation.page.html',
  styleUrls: ['./create-conversation.page.scss'],
})
export class CreateConversationPage implements OnInit {

  constructor(private readonly store : Store<CreateConversationPageState> ) { }

  users$ : Observable<UserResponse[]> = this.store.select(selectUserResponses)

  ngOnInit() {

    this.users$.pipe(first()).subscribe(x => {
      console.log(x);
      if(x.length == 0)
        this.store.dispatch(nextPageUsersAction())
    })

  }


}
