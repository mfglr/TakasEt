import { Component } from '@angular/core';
import { UserState } from './states/user/state';
import { Store } from '@ngrx/store';
import { getLoginResponse, isLogin } from './states/user/selector';
import { PostService } from './services/post.service';
import { loginFromLocalStorage } from './states/user/actions';
import { filter, map, mergeMap } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent{
  private postId = "7abbd9b4-4033-4940-8e2d-1ff9c97f7e19";
  isLogin$ = this.store.select(isLogin)

  userId$ =  this.isLogin$.pipe(
    filter(x => x),
    mergeMap( () => this.store.select(getLoginResponse)),
    map(x => x!.id)
  )
  constructor(
    private store : Store<UserState>,
    private postService : PostService,

    ) {
    }

    ngOnInit(){
      this.store.dispatch(loginFromLocalStorage());

    }
}
