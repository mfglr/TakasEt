import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, mergeMap } from 'rxjs';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';
import { isLogin } from 'src/app/states/user/selector';
import { UserState } from 'src/app/states/user/state';

@Component({
  selector: 'app-display-post',
  templateUrl: './display-post.component.html',
  styleUrls: ['./display-post.component.scss']
})
export class DisplayPostComponent {
  @Input() postId? : string;
  @Input() userId? : string;

  isLogin$ = this.store.select(isLogin).pipe(
    filter(x => x)
  )

  constructor(
    private postService : PostService,
    private store : Store<UserState>,
    private userService : UserService
    ) {
    }

  urls$ = this.isLogin$.pipe(
    mergeMap( () => this.postService.getPostImagesByPostId(this.postId!))
  )

  post$ = this.isLogin$.pipe(
    mergeMap( () => this.postService.getById(this.postId!))
  )

  profileImage$ = this.isLogin$.pipe(
    mergeMap( () => this.userService.getActiveProfileImage(this.userId!) )
  )

}
