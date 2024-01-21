import { Component, Input } from '@angular/core';
import { SwitchButton } from '../switch-button';
import { Store } from '@ngrx/store';
import { LoginState } from 'src/app/states/login_state/reducer';
import { Observable, filter, first, map, mergeMap } from 'rxjs';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { AppState } from '@capacitor/app';

@Component({
  selector: 'app-follow-button',
  templateUrl: './follow-button.component.html',
  styleUrls: ['./follow-button.component.scss'],
})
export class FollowButtonComponent {

  @Input() userId? : number | null;
  isFollowed$? : Observable<boolean | undefined>
  switchButton? : SwitchButton;

  constructor(
    private appStore : Store<AppState>,
    private loginStore : Store<LoginState>
  ) {}

  ngOnChanges() {
    // if(this.userId){

    //   this.isFollowed$ = this.userEntityStore.select(selectIsFollowed({userId : this.userId}))

    //   this.isFollowed$.pipe(
    //     filter(isFollowed => isFollowed != undefined),
    //     first(),
    //     map(isFollowed => isFollowed!)
    //   ).subscribe(
    //     isFollowed => {

    //       this.switchButton = new SwitchButton(isFollowed,500)

    //       this.switchButton.valueChanges.pipe(
    //         mergeMap(value => this.loginStore.select(selectUserId).pipe(
    //           map(loginUserId => ({loginUserId : loginUserId!, value : value}))
    //         ))
    //       ).subscribe(
    //         x => {
    //           this.profileStore.dispatch(addOrRemoveFollowedAction({
    //             followedId : this.userId!,value : x.value
    //           }))
    //           this.userEntityStore.dispatch(changeFollowingStatusAction({
    //             userId : this.userId!, logginUserId : x.loginUserId,value : x.value
    //           }))
    //         }
    //       )

    //       this.switchButton.commitValue.subscribe(
    //         x => this.userEntityStore.dispatch(commitFollowingStatusAction({
    //           userId : this.userId!,value : x
    //         }))
    //       )
    //     }
    //   )

    // }
  }
}

