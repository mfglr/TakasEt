import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from './state/reducer';
import { initUserPageStateAction, nextPageOfPostsAction } from './state/actions';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { selectPostIds } from './state/selectors';
import { UserState } from 'src/app/states/user-state/reducer';
import { UserResponse } from 'src/app/models/responses/user-response';
import { selectUser } from 'src/app/states/user-state/selectors';

@Component({
  selector: 'app-user',
  templateUrl: './user.page.html',
  styleUrls: ['./user.page.scss'],
})
export class UserPage implements OnInit {

  @Input() userId? : number;
  postIds$? : Observable<number[] | undefined>
  user$? : Observable<UserResponse | undefined>

  constructor(
    private userPageStore : Store<State>,
    private userStore : Store<UserState>
  ) { }

  ngOnInit() {
    if(this.userId){
      this.userPageStore.dispatch(initUserPageStateAction({userId : this.userId}))
      this.userPageStore.dispatch(nextPageOfPostsAction({userId : this.userId}))

      this.postIds$ = this.userPageStore.select(selectPostIds({userId : this.userId}))
      this.user$ = this.userStore.select(selectUser({id : this.userId}))
    }
  }

}
