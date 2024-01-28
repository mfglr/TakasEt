import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { UserResponse } from 'src/app/models/responses/user-response';
import { MessageHubConnectionService } from 'src/app/services/message-hub-connection.service';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit {

  user? : UserResponse;
  messageInput = new FormControl<string>("");

  constructor(
    private router : Router,
    private messageHub : MessageHubConnectionService
  ) {
    this.user = this.router.getCurrentNavigation()?.extras.state as UserResponse
  }

  ngOnInit() {
    this.messageHub.on("ReceiveMessage")
  }

  sendMessage(){
    this.messageHub.invoke("SendMessage",this.messageInput.value!)
  }

  openCamera(){
  }
}
