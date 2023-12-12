import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from './state/reducer';
import { initUserPageStateAction, nextPageOfPostsAction } from './state/actions';
import { Observable, Subscription, map, mergeMap } from 'rxjs';
import { selectPostIds } from './state/selectors';
import { UserState } from 'src/app/states/user-state/reducer';
import { UserResponse } from 'src/app/models/responses/user-response';
import { selectUser } from 'src/app/states/user-state/selectors';
import { ActivatedRoute } from '@angular/router';
import { loadUserAction } from 'src/app/states/user-state/actions';
import { ProfileImageState } from 'src/app/states/profile-image-state/reducer';
import { selectUrl } from 'src/app/states/post-image-state/selectors';
import { selectState } from 'src/app/states/profile-image-state/selectors';

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

  constructor(
    private userPageStore : Store<State>,
    private userStore : Store<UserState>,
    private activatedRoute : ActivatedRoute,
  ) { }

  ngOnInit() {
    this.userId$ = this.activatedRoute.paramMap.pipe(
      map(x => parseInt(x.get("id")!))
    )

    this.postIds$ = this.userId$.pipe(
      mergeMap(userId => this.userPageStore.select(selectPostIds({userId : userId})))
    )

    this.user$ = this.userId$.pipe(
      mergeMap(userId => this.userStore.select(selectUser({id : userId})))
    )

    this.subscription = this.userId$.subscribe(
      userId => {
        this.userPageStore.dispatch(initUserPageStateAction({userId : userId}))
        this.userPageStore.dispatch(nextPageOfPostsAction({userId : userId}))

        this.userStore.dispatch(loadUserAction({userId :userId}))
      }
    )

  }

  ngOnDestroy(){
    this.subscription?.unsubscribe();
  }

}
