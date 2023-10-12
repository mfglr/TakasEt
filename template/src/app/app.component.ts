import { Component } from '@angular/core';
import { UserState } from './states/user/state';
import { Store } from '@ngrx/store';
import { getLoginResponse, isLogin } from './states/user/selector';
import { PostService } from './services/post.service';
import { loginByRefreshToken, loginFromLocalStorage } from './states/user/actions';
import { filter, map, mergeMap } from 'rxjs';
import { UserFollowingService } from './services/user-following.service';
import { LoginResponse } from './models/responses/login-response';

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

  public followedId : string = '33a924ff-2ece-47b9-dcf0-08dbc7403361';
  constructor(
    private store : Store<UserState>,
    private postService : PostService,
    public userFollowing : UserFollowingService

    ) {
    }

    ngOnInit(){
      let data = localStorage.getItem('loginResponse');
      if(data){
        let loginResponse : LoginResponse = JSON.parse(data);
        if(new Date(loginResponse.expirationDateOfAccessToken).getTime() > Date.now())
          this.store.dispatch(loginFromLocalStorage());
        else
          this.store.dispatch(loginByRefreshToken({refreshToken : loginResponse.refreshToken}));
      }
    }
}
