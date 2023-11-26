import { Component, ElementRef, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { nextPageAction } from 'src/app/states/post-state/actions';
import { selectPostResponses } from 'src/app/states/post-state/selectors';
import { PagePostState, homePagePostList } from 'src/app/states/post-state/state';

@Component({
  selector: 'home-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class HomePostListComponent{
  @ViewChild("commentModalButton",{static : true}) commentModalButton? : ElementRef;

  posts$? = this.pagePostStore.select(selectPostResponses({pageId : homePagePostList}));
  postWithCommentDisplayed? : PostResponse;

  constructor(
    private pagePostStore : Store<PagePostState>
  ) {}

  ngOnInit(){
    this.pagePostStore.dispatch(nextPageAction({pageId : homePagePostList}))
  }

  displayComments(post : PostResponse){
    this.postWithCommentDisplayed = post;
    if(this.commentModalButton)
      this.commentModalButton.nativeElement.click();
  }

  getMore(){
    this.pagePostStore.dispatch(nextPageAction({pageId : homePagePostList}))
  }

}
