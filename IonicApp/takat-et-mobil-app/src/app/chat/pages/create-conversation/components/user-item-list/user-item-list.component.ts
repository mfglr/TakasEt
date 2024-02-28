import { Component, Input, OnInit } from '@angular/core';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-user-item-list',
  templateUrl: './user-item-list.component.html',
  styleUrls: ['./user-item-list.component.scss'],
})
export class UserItemListComponent  implements OnInit {

  @Input() users? : UserResponse[] | null;
  constructor() { }
  ngOnInit() {}

}
