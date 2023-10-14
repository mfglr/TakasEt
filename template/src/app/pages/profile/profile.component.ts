import { Component, OnChanges } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, mergeMap } from 'rxjs';
import { ObservableHelpers } from 'src/app/helpers/observable-helpers';
import { PostImageService } from 'src/app/services/post-image.service';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';
import { getLoginResponse } from 'src/app/states/user/selector';
import { UserState } from 'src/app/states/user/state';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent{

  data$ = this.store.select(getLoginResponse).pipe(
    filter(x => !(!x)),
    mergeMap(loginResponse => this.postService.getPostsWithFirstImagesByUserId(loginResponse!.id))
  )

  user$ = this.store.select(getLoginResponse).pipe(
    filter(x => !(!x)),
    mergeMap(x => this.userService.getUser(x!.id))
  )

  constructor(
    private postImageService : PostImageService,
    private postService : PostService,
    private store : Store<UserState>,
    private userService : UserService
    ) {

  }

}
