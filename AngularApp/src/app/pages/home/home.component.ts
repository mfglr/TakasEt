import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, first, map } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { PostResponse } from 'src/app/models/responses/post-response';
import { nextPageOfChildren, nextPageOfComments, nextPageOfPostLikers, nextPageOfPosts, setSelectedCommentId, setSelectedPostId } from 'src/app/states/home-page/actions';
import { HomePageState } from 'src/app/states/home-page/reducer';
import { comments, selectSelectedCommentResponses } from 'src/app/states/home-page/selectors/comments-selectors';
import { selectPostReponsesOfHomePage, selectSelectedCommentId } from 'src/app/states/home-page/selectors/home-page-selectors';
import { selectSelectedUserResponsesOfLiker } from 'src/app/states/home-page/selectors/likers-selectors';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild("commentModalButton",{static : true}) commentModalButton? : ElementRef;
  @ViewChild("usersListModalButton",{static : true}) usersListModalButton? : ElementRef;

  mappedComments$ = this.store.select(comments);
  posts$ = this.store.select(selectPostReponsesOfHomePage)
  postLikers$ = this.store.select(selectSelectedUserResponsesOfLiker)
  postForComments? : PostResponse;

  constructor(
    private store : Store<HomePageState>
  ) {}

  ngOnInit(): void {
    this.posts$.pipe(
      first(),
      filter( x => x.length <= 0),
      map(() => this.store.dispatch(nextPageOfPosts()) )
    ).subscribe();

    this.mappedComments$.subscribe(x => console.log(x))
  }

  getMore(){ this.store.dispatch(nextPageOfPosts()) }
  getNextPageOfComments(){ this.store.dispatch(nextPageOfComments()) }
  getNextPageOfChildren(){ this.store.dispatch(nextPageOfChildren()) }
  getNextPageOfPostLikers(){ this.store.dispatch(nextPageOfPostLikers()) }

  displayComments(post : PostResponse){
    this.postForComments = post;
    if(this.commentModalButton) {
      this.commentModalButton.nativeElement.click();
    }
  }

  displayPostLikers(post : PostResponse){
    if(this.usersListModalButton){
      this.usersListModalButton.nativeElement.click();
    }
  }

  displayViewers(post:PostResponse){

  }
  setSelectedPost(post : PostResponse){ this.store.dispatch(setSelectedPostId({postId : post.id})) }
  setSelectedComment(comment : CommentResponse){ this.store.dispatch(setSelectedCommentId({commentId : comment.id})) }
}
