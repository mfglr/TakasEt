import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import * as UserSelector from "src/app/states/user/selector"
import { Observable, Subscription, filter, first, map } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserState } from 'src/app/states/user/state';
import { nextPageOfComments } from 'src/app/states/home-page/actions';
import { HomePageState } from 'src/app/states/home-page/reducer';
import { selectCommentResponsesOfPostReponse } from 'src/app/states/home-page/selectors';
@Component({
  selector: 'app-comment-modal',
  templateUrl: './comment-modal.component.html',
  styleUrls: ['./comment-modal.component.scss']
})
export class CommentModalComponent implements OnChanges, OnDestroy {
  @Input() post? : PostResponse;
  @Output() postCommentCountVector = new EventEmitter<number>();
  comments$? : Observable<CommentResponse[]>
  respondedComment : CommentResponse | null = null;
  userId? : string;

  userIdSubscription = this.userStore.select(UserSelector.getLoginResponse).subscribe(
    x => this.userId = x?.id
  );

  private respondedCommentSubscription? : Subscription;
  commentForm = new FormGroup({
    parentId : new FormControl<string | undefined>(undefined),
    postId : new FormControl<string | undefined>(undefined),
    userId : new FormControl<string>(''),
    content : new FormControl<string>('')
  });

  constructor(
    private userStore : Store<UserState>,
    private homeStore : Store<HomePageState>
  ) {}

  getMore(){
    this.homeStore.dispatch(nextPageOfComments())
  }

  ngOnInit(){
  }
  ngOnChanges() {
    if(this.post){
      this.comments$ = this.homeStore.select(selectCommentResponsesOfPostReponse({postId : this.post.id}))
      this.commentForm.patchValue({
          postId : this.post.id,
          userId : this.userId
      })
    }
  }
  publishComment(){
    if(this.commentForm.value.postId) this.postCommentCountVector.emit(1);
    if(this.post)
      this.commentForm.patchValue( { postId : this.post.id,parentId : null,content : ''})
  }

  ngOnDestroy(): void {
    this.respondedCommentSubscription?.unsubscribe()
  }
}
