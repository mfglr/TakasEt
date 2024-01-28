import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { CreateMessagePageState } from './state/reducer';
import { selectUserResponses } from './state/selectors';
import { first } from 'rxjs';
import { nextPageUsersAction } from './state/actions';

@Component({
  selector: 'app-create-message',
  templateUrl: './create-message.page.html',
  styleUrls: ['./create-message.page.scss'],
})
export class CreateMessagePage implements OnInit {

  constructor(
    private createMessagePageStore : Store<CreateMessagePageState>
  ) { }

  users$ = this.createMessagePageStore.select(selectUserResponses);

  ngOnInit() {
    this.users$.pipe(first()).subscribe(
      users => {
        if(!users.length)
          this.createMessagePageStore.dispatch(nextPageUsersAction())
      }
    )
  }

}
