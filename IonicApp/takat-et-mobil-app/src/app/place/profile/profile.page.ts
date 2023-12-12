import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { LoginState } from 'src/app/states/login_state/reducer';
import { UserState } from 'src/app/states/user-state/reducer';
import { ProfilePageState } from './state/reducer';
import { changeActiveTabAction, nextPageAction } from './state/actions';
import { selectActiveTab, selectPostIds } from './state/selectors';
import { UserResponse } from 'src/app/models/responses/user-response';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { selectUser } from 'src/app/states/user-state/selectors';
import { Subscription, filter, mergeMap } from 'rxjs';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit{

  subs? : Subscription;
  user? : UserResponse;
  activeTab$? = this.profilePageStore.select(selectActiveTab);
  postIds$ = this.profilePageStore.select(selectPostIds)

  constructor(
    private loginStore : Store<LoginState>,
    private userStore : Store<UserState>,
    private profilePageStore : Store<ProfilePageState>
  ) { }

  ngOnInit() {
    this.profilePageStore.dispatch(nextPageAction())

    this.subs = this.loginStore.select(selectUserId).pipe(
      filter(userId => userId != undefined),
      mergeMap(userId => this.userStore.select(selectUser({id : userId!})))
    ).subscribe( response => this.user = response )
  }

  changeActiveTab(activeTab : number){
    this.profilePageStore.dispatch(changeActiveTabAction({activeTab : activeTab}))
  }

  ngOnDestroy(){
    this.subs?.unsubscribe();
  }
}
