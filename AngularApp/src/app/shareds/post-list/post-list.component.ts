import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import * as appPostsActions from 'src/app/states/post_state/actions';
import * as appPostsSelectors from 'src/app/states/post_state/selectors';
import { AppPostState } from 'src/app/states/post_state/state';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent{
  @ViewChild("commentModalButton",{static : true}) commentModalButton? : ElementRef;

  @Input() queryId? : string;
  posts$? : Observable<PostResponse[]>
  constructor(
    private postsStore : Store<AppPostState>
  ) {}

  ngOnChanges(){
    if(this.queryId){
      this.posts$ = this.postsStore.select(appPostsSelectors.selectPostResponses({ queryId: this.queryId}));
    }
  }
  getMore(){
    this.postsStore.dispatch(appPostsActions.nextPageOfPosts())
  }

}
