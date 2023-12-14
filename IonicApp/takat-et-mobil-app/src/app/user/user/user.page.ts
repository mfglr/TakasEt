import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { UserPageCollectionState } from './state/reducer';
import { initUserPageStateAction } from './state/actions';
import { Observable, Subscription, map, mergeMap } from 'rxjs';
import { UserState } from 'src/app/states/user-state/reducer';
import { UserResponse } from 'src/app/models/responses/user-response';
import { selectUser } from 'src/app/states/user-state/selectors';
import { ActivatedRoute } from '@angular/router';
import { loadUserAction } from 'src/app/states/user-state/actions';
import { UserModuleCollectionState } from '../state/reducer';
import { initUserModuleAction, nextPostsAction } from '../state/actions';
import { selectPostIds } from '../state/selectors';

@Component({
  selector: 'app-user',
  templateUrl: './user.page.html',
  styleUrls: ['./user.page.scss'],
})
export class UserPage implements OnInit {

  userId$? : Observable<number>;
  postIds$? : Observable<number[] | undefined>
  user$? : Observable<UserResponse | undefined>
  subscription? : Subscription;
  isLoggedInUser : boolean = false;

  constructor(
    private userPageCollectionStore : Store<UserPageCollectionState>,
    private userModuleCollectionStore : Store<UserModuleCollectionState>,
    private userStore : Store<UserState>,
    private activatedRoute : ActivatedRoute
  ) { }

  ngOnInit() {
    this.userId$ = this.activatedRoute.paramMap.pipe(
      map(x => parseInt(x.get("userId")!))
    )

    this.postIds$ = this.userId$.pipe(
      mergeMap(userId => this.userModuleCollectionStore.select(selectPostIds({userId : userId})))
    )

    this.user$ = this.userId$.pipe(
      mergeMap(userId => this.userStore.select(selectUser({userId : userId})))
    )

    this.subscription = this.userId$.subscribe(
      userId => {
        this.userModuleCollectionStore.dispatch(initUserModuleAction({userId : userId}))
        this.userPageCollectionStore.dispatch(initUserPageStateAction({userId : userId}))

        this.userStore.dispatch(loadUserAction({userId :userId}))
        this.userModuleCollectionStore.dispatch(nextPostsAction({userId : userId}))
      }
    )

  }

  ngOnDestroy(){
    this.subscription?.unsubscribe();
  }

}
