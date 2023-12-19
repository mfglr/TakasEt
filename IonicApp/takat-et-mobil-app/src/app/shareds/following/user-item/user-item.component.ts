import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UserResponse } from 'src/app/models/responses/user-response';
import { UserEntityState } from 'src/app/states/user-entity-state/reducer';
import { selectUser } from 'src/app/states/user-entity-state/selectors';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styleUrls: ['./user-item.component.scss'],
})
export class UserItemComponent{

  @Input() userId? : number;
  user$? : Observable<UserResponse | undefined>

  constructor(
    private userEntityStore : Store<UserEntityState>
  ) { }

  ngOnChanges(){
    if(this.userId){
      this.user$ = this.userEntityStore.select(selectUser({userId : this.userId}))
    }
  }

}
