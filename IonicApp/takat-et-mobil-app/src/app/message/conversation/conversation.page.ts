import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { filter, first } from 'rxjs';
import { UserResponse } from 'src/app/models/responses/user-response';
import { MessageHubConnectionService } from 'src/app/services/message-hub-connection.service';
import { AppState } from 'src/app/state/reducer';
import { selectUserId } from 'src/app/state/selector';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit {

  user? : UserResponse;
  messageInput = new FormControl<string>("");
  userId$ = this.appStore.select(selectUserId);

  constructor(
    private router : Router,
    private messageHub : MessageHubConnectionService,
    private appStore : Store<AppState>
  ) {
    this.user = this.router.getCurrentNavigation()?.extras.state as UserResponse
  }

  ngOnInit() {
    this.messageHub.on("SavedMessageSuccess").pipe()
  }

  sendMessage(){

    if(this.user){
      this.userId$.pipe(
        first(),
        filter(userId => userId != undefined)
      ).subscribe(userId => {
        this.messageHub.invoke(
          "SaveMessage",
          {
            content : this.messageInput.value!,
            senderId : userId,
            receiverId : this.user!.id
          }
        )
      })
    }

  }

  openCamera(){
  }
}
