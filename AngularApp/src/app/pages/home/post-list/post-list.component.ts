import { Component, ElementRef, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { nextPageOfPosts } from 'src/app/states/home_page_state/actions';
import { selectPostResponses } from 'src/app/states/home_page_state/selectors';
import { HomePageState } from 'src/app/states/home_page_state/state';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent{
  @ViewChild("commentModalButton",{static : true}) commentModalButton? : ElementRef;

  posts$? = this.homePageStore.select(selectPostResponses);
  postWithCommentDisplayed? : PostResponse;

  constructor(
    private homePageStore : Store<HomePageState>
  ) {}

  ngOnInit(){
    this.homePageStore.dispatch(nextPageOfPosts())
  }

  displayComments(post : PostResponse){
    this.postWithCommentDisplayed = post;
    if(this.commentModalButton)
      this.commentModalButton.nativeElement.click();
  }

  getMore(){
    this.homePageStore.dispatch(nextPageOfPosts())
  }

}
