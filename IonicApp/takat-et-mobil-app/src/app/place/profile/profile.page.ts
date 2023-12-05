import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, mergeMap } from 'rxjs';
import { LoginState } from 'src/app/states/login_state/reducer';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { UserState } from 'src/app/states/user-state/reducer';
import { selectUser } from 'src/app/states/user-state/selectors';
import { ProfilePageState } from './state/reducer';
import { nextPageAction } from './state/actions';
import { selectPostIds } from './state/selectors';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {

  user$ = this.loginStore.select(selectUserId).pipe(
    filter(userId => userId != undefined),
    mergeMap(userId => this.userStore.select(selectUser({id : userId!})))
  )

  postIds$ = this.profilePageStore.select(selectPostIds)

  constructor(
    private loginStore : Store<LoginState>,
    private userStore : Store<UserState>,
    private profilePageStore : Store<ProfilePageState>
  ) { }

  ngOnInit() {
    this.profilePageStore.dispatch(nextPageAction())
  }

}
