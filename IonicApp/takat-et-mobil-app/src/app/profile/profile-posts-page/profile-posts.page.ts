import { Component } from '@angular/core';
import { ProfileModuleState } from '../state/reducer';
import { Store } from '@ngrx/store';
import { take } from 'rxjs';
import { selectPostIds } from '../state/selectors';
import { nextPostsAction } from '../state/actions';

@Component({
  selector: 'app-profile-posts-page',
  templateUrl: './profile-posts.page.html',
  styleUrls: ['./profile-posts.page.scss'],
})
export class ProfilePostsPage {

  postIds$ = this.profileModuleStore.select(selectPostIds);
  initiliazer = this.postIds$.pipe(take(1)).subscribe(
    postIds => {
      if(!postIds.length)
        this.profileModuleStore.dispatch(nextPostsAction())
    }
  )

  constructor(
    private profileModuleStore : Store<ProfileModuleState>,
  ) { }

  ngOnDestroy(){
    this.initiliazer.unsubscribe();
  }
}
