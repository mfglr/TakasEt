import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-create-message-item',
  templateUrl: './create-message-item.component.html',
  styleUrls: ['./create-message-item.component.scss'],
})
export class CreateMessageItemComponent{

  @Input() user? : UserResponse

  constructor(private router : Router) {}

}
