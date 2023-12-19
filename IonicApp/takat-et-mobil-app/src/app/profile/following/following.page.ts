import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, map, mergeMap } from 'rxjs';
import { LoginState } from 'src/app/states/login_state/reducer';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { ProfileState } from 'src/app/states/profile-state/reducer';
import { selectFollowedIds, selectFollowerIds } from 'src/app/states/profile-state/selectors';
import { ProfileFollowingPageState } from './state/reducer';
import { selectActiveTab } from './state/selectors';
import { nextFollowedsAction, nextFollowersAction } from 'src/app/states/profile-state/actions';
import { changeActiveTabAction } from './state/actions';

@Component({
  selector: 'app-following',
  templateUrl: './following.page.html',
  styleUrls: ['./following.page.scss'],
})
export class FollowingPage implements OnInit {

  userId$ = this.loginStore.select(selectUserId);
  activeTab$ = this.profileFollowingPageStore.select(selectActiveTab);
  followerIds$ = this.profileStore.select(selectFollowerIds);
  followedIds$ = this.profileStore.select(selectFollowedIds);

  ids = [this.followerIds$,this.followedIds$];


  constructor(
    private profileFollowingPageStore : Store<ProfileFollowingPageState>,
    private profileStore : Store<ProfileState>,
    private loginStore : Store<LoginState>
  ) { }

  ngOnInit() {
    this.userId$.pipe(
      filter(userId => userId != undefined),
      map(userId => userId!),
      mergeMap(userId => this.activeTab$.pipe(
        mergeMap(activeTab => this.ids[activeTab].pipe(
          map(ids => {
            if(!ids || !ids.length){
              if(activeTab == 0) this.profileStore.dispatch(nextFollowersAction())
              else this.profileStore.dispatch(nextFollowedsAction())
            }
          })
        ))
      ))
    ).subscribe();
  }

  changeActiveTab(e : any){
    this.profileFollowingPageStore.dispatch(changeActiveTabAction({activeTab : e.detail[0].activeIndex}))
  }


}
