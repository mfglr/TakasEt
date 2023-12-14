import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, map, mergeMap, take } from 'rxjs';
import { LoginState } from 'src/app/states/login_state/reducer';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { UserState } from 'src/app/states/user-state/reducer';
import { selectUser } from 'src/app/states/user-state/selectors';
import { ProfilePageState } from './state/reducer';
import { selectActiveTab } from './state/selectors';
import { ProfileModuleState } from '../state/reducer';
import { selectNotSwappedPostIds, selectPostIds, selectSwappedPostIds } from '../state/selectors';
import { nextNotSwappedPostsAction, nextPostsAction, nextSwappedPostsAction } from '../state/actions';
import { changeActiveTabAction } from './state/actions';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {

  user$ = this.loginStore.select(selectUserId).pipe(
    filter(userId => userId != undefined),
    mergeMap(userId => this.userStore.select(selectUser({userId : userId!})))
  );

  activeTab$? = this.profilePageStore.select(selectActiveTab);

  postIds$ = this.profileModuleStore.select(selectPostIds)
  swappedPostIds$ = this.profileModuleStore.select(selectSwappedPostIds);
  notSwappedPostIds$ = this.profileModuleStore.select(selectNotSwappedPostIds);

  ids = [this.postIds$,this.swappedPostIds$,this.notSwappedPostIds$];

  constructor(
    private loginStore : Store<LoginState>,
    private userStore : Store<UserState>,
    private profilePageStore : Store<ProfilePageState>,
    private profileModuleStore : Store<ProfileModuleState>
  ) { }


  ngOnInit(){
    this.nextPosts();
  }

  nextPosts(){
    this.activeTab$?.pipe(
      take(1),
      mergeMap(activeTab => this.ids[activeTab].pipe(
        map(x =>{
          if(x.length == 0){
            if(activeTab == 0) this.profilePageStore.dispatch(nextPostsAction())
            else if(activeTab == 1) this.profilePageStore.dispatch(nextSwappedPostsAction())
            else if(activeTab == 2) this.profilePageStore.dispatch(nextNotSwappedPostsAction())
          }
        })
      )),
    ).subscribe()
  }

  changeActiveTab(activeTab : number){
    this.profilePageStore.dispatch(changeActiveTabAction({activeTab : activeTab}))
    this.nextPosts()
  }
}
