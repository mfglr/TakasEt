import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, map, mergeMap, take } from 'rxjs';
import { ProfilePageState } from './state/reducer';
import { selectActiveTab } from './state/selectors';
import { changeActiveTabAction } from './state/actions';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {

  // user$ = this.loginStore.select(selectUserId).pipe(
  //   filter(userId => userId != undefined),
  //   mergeMap(userId => this.userStore.select(selectUser({userId : userId!})))
  // );

  tags = [
    {icon : 'fa-solid fa-table-cells-large',name : undefined},
    {icon : 'fa-solid fa-handshake-simple',name : undefined},
    {icon : 'fa-solid fa-handshake-simple-slash',name : undefined}
  ]

  activeTab$? = this.profilePageStore.select(selectActiveTab);

  // postIds$ = this.profileStore.select(selectPostIds)
  // swappedPostIds$ = this.profileStore.select(selectSwappedPostIds);
  // notSwappedPostIds$ = this.profileStore.select(selectNotSwappedPostIds);

  // ids = [this.postIds$,this.swappedPostIds$,this.notSwappedPostIds$];

  constructor(
    private profilePageStore : Store<ProfilePageState>,
  ) { }


  ngOnInit(){
    this.nextPosts();
  }

  nextPosts(){
    // this.activeTab$?.pipe(
    //   take(1),
    //   mergeMap(activeTab => this.ids[activeTab].pipe(
    //     map(x =>{
    //       if(x.length == 0){
    //         if(activeTab == 0) this.profilePageStore.dispatch(nextPostsAction())
    //         else if(activeTab == 1) this.profilePageStore.dispatch(nextSwappedPostsAction())
    //         else if(activeTab == 2) this.profilePageStore.dispatch(nextNotSwappedPostsAction())
    //       }
    //     })
    //   )),
    // ).subscribe()
  }

  changeActiveTab(activeTab : number){
    this.profilePageStore.dispatch(changeActiveTabAction({activeTab : activeTab}))
    this.nextPosts()
  }
}
