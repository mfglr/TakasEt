import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styleUrls: ['./user-item.component.scss'],
})
export class UserItemComponent  implements OnInit {

  @Input()  userId? : number;

  user$? : Observable<UserResponse | undefined>;

  constructor(
  ) { }

  ngOnInit() {
    if(this.userId){
    }
  }

}
