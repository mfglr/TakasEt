import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { initCommentModalStatesAction } from 'src/app/states/comment_modal_state/action';
import { CommentModalStateCollection, initCommentModalStates } from 'src/app/states/comment_modal_state/state';
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
  postWithCommentDisplayed? : PostResponse;

  constructor(
    private postsStore : Store<AppPostState>,
    private commentModalStore : Store<CommentModalStateCollection>
  ) {}

  ngOnChanges(){
    if(this.queryId){
      this.posts$ = this.postsStore.select(appPostsSelectors.selectPostResponses({ queryId: this.queryId}));
      this.posts$.subscribe(
        posts => this.commentModalStore.dispatch(initCommentModalStatesAction({postIds : posts.map(post => post.id)}))
      )
    }
  }

  displayComments(post : PostResponse){
    this.postWithCommentDisplayed = post;
    if(this.commentModalButton)
      this.commentModalButton.nativeElement.click();

  }

  getMore(){
    this.postsStore.dispatch(appPostsActions.nextPageOfPosts())
  }

}
