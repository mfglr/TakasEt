import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs';
import { nextPostsAction } from 'src/app/states/profile-state/actions';
import { ProfileState } from 'src/app/states/profile-state/reducer';
import { selectPostIds } from 'src/app/states/profile-state/selectors';

@Component({
  selector: 'app-profile-posts-page',
  templateUrl: './profile-posts.page.html',
  styleUrls: ['./profile-posts.page.scss'],
})
export class ProfilePostsPage {

  postIds$ = this.profileStore.select(selectPostIds);
  initiliazer = this.postIds$.pipe(take(1)).subscribe(
    postIds => {
      if(!postIds.length)
        this.profileStore.dispatch(nextPostsAction())
    }
  )

  constructor(
    private profileStore : Store<ProfileState>,
  ) { }

  ngOnDestroy(){
    this.initiliazer.unsubscribe();
  }
}
