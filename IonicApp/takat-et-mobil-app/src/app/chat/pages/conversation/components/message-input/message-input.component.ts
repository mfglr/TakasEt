import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Store } from '@ngrx/store';
import { sendMessageAction } from '../../state/actions';
import { State } from '../../state/reducer';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { first } from 'rxjs';

@Component({
  selector: 'app-message-input',
  templateUrl: './message-input.component.html',
  styleUrls: ['./message-input.component.scss'],
})
export class MessageInputComponent  implements OnInit {

  @Input() receiverId? : string;
  messageInput = new FormControl<string>("");
  userId$ = this.loginStore.select(selectUserId);

  constructor(
    private readonly store : Store<State>,
    private readonly loginStore : Store<LoginState>
  ) { }

  ngOnInit() {}

  sendMessage(){

    this.userId$.pipe(first()).subscribe(userId => {

      if(this.messageInput.value && this.receiverId){

        this.store.dispatch(
          sendMessageAction({
            request : {
              id : crypto.randomUUID(),
              senderId : userId!,
              content : this.messageInput.value,
              receiverId : this.receiverId,
            }
          })
        )

        this.messageInput.setValue('');
      }

    });

  }


}
