import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { UserResponse } from 'src/app/models/responses/user-response';
import { EntityFollowingState } from 'src/app/states/following-state/reducer';
import { selectNumberOfFolloweds, selectNumberOfFollowers } from 'src/app/states/following-state/selectors';

@Component({
  selector: 'app-user-info-header',
  templateUrl: './user-info-header.component.html',
  styleUrls: ['./user-info-header.component.scss'],
})
export class UserInfoHeaderComponent{

  @Input() user? : UserResponse | null;

  numberOfFolloweds$? : Observable<number | undefined>
  numberOfFollowers$? : Observable<number | undefined>

  constructor(
    private entityFollowingState : Store<EntityFollowingState>
  ) { }

  ngOnChanges() {
    if(this.user){
      this.numberOfFolloweds$ = this.entityFollowingState.select(selectNumberOfFolloweds({userId : this.user.id}))
      this.numberOfFollowers$ = this.entityFollowingState.select(selectNumberOfFollowers({userId : this.user.id}))
    }
  }

}
