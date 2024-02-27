import { Component, Input, OnInit } from '@angular/core';
import { UserImageResponse } from 'src/app/models/responses/user-image-response';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styleUrls: ['./user-item.component.scss'],
})
export class UserItemComponent  implements OnInit {

  @Input() user? : UserResponse;
  constructor() { }

  ngOnInit() {}

}
