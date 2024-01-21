import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { UserPageCollectionState } from './state/reducer';
import { changeActiveTabAction, initUserPageStateAction } from './state/actions';
import { filter, first, map, mergeMap, take } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { UserModuleCollectionState } from '../state/reducer';
import { initUserModuleStateAction, nextNotSwappedPostsAction, nextPostsAction, nextSwappedPostsAction } from '../state/actions';
import { selectActiveTab } from './state/selectors';

@Component({
  selector: 'app-user',
  templateUrl: './user.page.html',
  styleUrls: ['./user.page.scss'],
})
export class UserPage{

  // userId$ = this.activatedRoute.paramMap.pipe( map(x => parseInt(x.get("userId")!)))

  // activeTab$ = this.userId$.pipe(
  //   mergeMap(userId => this.userPageCollectionStore.select(selectActiveTab({userId : userId})))
  // )
  // postIds$ = this.userId$.pipe(
  //   mergeMap(userId => this.userModuleCollectionStore.select(selectPostIds({userId : userId})))
  // )
  // swappedPostIds$ = this.userId$.pipe(
  //   mergeMap(userId => this.userModuleCollectionStore.select(selectSwappedPostIds({userId : userId})))
  // )
  // notSwappedPostIds$ = this.userId$.pipe(
  //   mergeMap(userId => this.userModuleCollectionStore.select(selectNotSwappedPostIds({userId : userId})))
  // )
  // ids = [this.postIds$,this.swappedPostIds$,this.notSwappedPostIds$];

  // user$ = this.userId$.pipe(
  //   mergeMap(userId => this.userStore.select(selectUser({userId : userId})))
  // )

  // constructor(
  //   private userPageCollectionStore : Store<UserPageCollectionState>,
  //   private userModuleCollectionStore : Store<UserModuleCollectionState>,
  //   private userStore : Store<UserState>,
  //   private activatedRoute : ActivatedRoute
  // ) { }

  // ngOnInit() {
  //   this.userId$.pipe(first()).subscribe( // initializer
  //     userId => {
  //       this.userModuleCollectionStore.dispatch(initUserModuleStateAction({userId : userId}))
  //       this.userPageCollectionStore.dispatch(initUserPageStateAction({userId : userId}))
  //       this.userStore.dispatch(loadUserAction({userId : userId}))
  //       this.nextPosts()
  //     }
  //   )
  // }

  // nextPosts(){
  //   this.activeTab$.pipe(
  //     filter(activeTab => activeTab != undefined),
  //     first(),
  //     mergeMap(activeTab => this.ids[activeTab!].pipe(
  //       first(),
  //       mergeMap(ids => this.userId$.pipe(
  //         first(),
  //         map(userId => {
  //           if(!ids || !ids.length){
  //             if(activeTab == 0)
  //               this.userModuleCollectionStore.dispatch(nextPostsAction({userId : userId}))
  //             else if(activeTab == 1)
  //               this.userModuleCollectionStore.dispatch(nextSwappedPostsAction({userId : userId}))
  //             else if(activeTab == 2)
  //               this.userModuleCollectionStore.dispatch(nextNotSwappedPostsAction({userId : userId}))
  //           }
  //         })
  //       ))
  //     ))
  //   ).subscribe()
  // }

  // changeActiveTab(activeTab : number){
  //   this.activeTab$.pipe(
  //     first(),
  //     filter(activeTab => activeTab != undefined),
  //     mergeMap(activeTab => this.userId$.pipe(
  //       first(),
  //       map(userId => {
  //         this.userPageCollectionStore.dispatch(changeActiveTabAction({userId : userId, activeTab : activeTab!}))
  //         this.nextPosts()
  //       })
  //     ))
  //   ).subscribe();
  // }

}
