import { Component, Input, OnInit } from '@angular/core';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-create-message-list',
  templateUrl: './create-message-list.component.html',
  styleUrls: ['./create-message-list.component.scss'],
})
export class CreateMessageListComponent{
  @Input() users? : UserResponse[] | null
}
