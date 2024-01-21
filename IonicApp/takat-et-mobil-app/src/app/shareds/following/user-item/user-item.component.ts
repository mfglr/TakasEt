import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styleUrls: ['./user-item.component.scss'],
})
export class UserItemComponent{

  @Input() userId? : number;
  user$? : Observable<UserResponse | undefined>

  constructor(
  ) { }

  ngOnChanges(){
    if(this.userId){
    }
  }

}
