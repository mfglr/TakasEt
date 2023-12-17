import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { UserResponse } from 'src/app/models/responses/user-response';
import { EntityFollowingState } from 'src/app/states/following-state/reducer';
import { SwitchButton } from '../switch-button';
import { commitFollowedValueAction, initFollowingStateAction, changeFollowedValueAction } from 'src/app/states/following-state/actions';
import { Observable } from 'rxjs';
import { selectIsFollowed } from 'src/app/states/following-state/selectors';

@Component({
  selector: 'app-follow-button',
  templateUrl: './follow-button.component.html',
  styleUrls: ['./follow-button.component.scss'],
})
export class FollowButtonComponent {

  @Input() user? : UserResponse | null;
  switchButton? : SwitchButton;
  isFollowed$? : Observable<boolean | undefined>

  constructor(
    private entityFollowingStore : Store<EntityFollowingState>
  ) { }

  ngOnChanges() {
    if(this.user){

      this.entityFollowingStore.dispatch(initFollowingStateAction({user : this.user}))
      this.isFollowed$ = this.entityFollowingStore.select(selectIsFollowed({userId : this.user.id}))

      this.switchButton = new SwitchButton(this.user.isFollowed,500);
      this.switchButton.valueChanges.subscribe(
        x => {
          this.entityFollowingStore.dispatch(changeFollowedValueAction({userId : this.user!.id,value : x}))
        }
      )
      this.switchButton.commitValue.subscribe(
        x => this.entityFollowingStore.dispatch(commitFollowedValueAction({userId : this.user!.id}))
      )

    }
  }

}
