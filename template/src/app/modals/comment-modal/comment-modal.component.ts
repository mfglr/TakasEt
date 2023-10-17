import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AddComment } from 'src/app/models/requests/add-comment';
import { PostResponse } from 'src/app/models/responses/post-response';
import { CommentState } from 'src/app/states/comment/reducer';
import * as CommentActions from 'src/app/states/comment/actions'
import * as CommentSelectors from "src/app/states/comment/selector";
import * as UserSelector from "src/app/states/user/selector"
import { Subscription, filter } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserState } from 'src/app/states/user/state';
@Component({
  selector: 'app-comment-modal',
  templateUrl: './comment-modal.component.html',
  styleUrls: ['./comment-modal.component.scss']
})
export class CommentModalComponent implements OnChanges, OnDestroy {
  @Input() post? : PostResponse;
  @Output() postCommentCountVector = new EventEmitter<number>();
  respondedComment : CommentResponse | null = null;
  userId? : string;

  userIdSubscription = this.userStore.select(UserSelector.getLoginResponse).subscribe(
    x => this.userId = x?.id
  );

  private respondedCommentSubscription? : Subscription;

  cancelRespondingComment(){
    this.store.dispatch(CommentActions.setRespondedComment({ comment : null}));
  }

  comments$ = this.store.select(CommentSelectors.selectComments)

  commentForm = new FormGroup({
    parentId : new FormControl<string | undefined>(undefined),
    postId : new FormControl<string | undefined>(undefined),
    userId : new FormControl<string>(''),
    content : new FormControl<string>('')
  });

  constructor(
    private store : Store<CommentState>,
    private userStore : Store<UserState>
  ) {}
  commets$? = this.store.select(CommentSelectors.selectComments).subscribe(x => console.log(x))
  ngOnChanges() {
    if(this.post){

      this.store.dispatch(CommentActions.getCommentsByPostId({ postId : this.post.id}))

      this.commentForm.patchValue({
          postId : this.post.id,
          userId : this.userId
      })
      // this.respondedCommentSubscription = this.store.select(CommentSelectors.getRespondedComment).subscribe(
      //   x => {
      //     this.respondedComment = x;
      //     if(x)
      //       this.commentForm.patchValue({ postId : null,parentId : x.id,content : `@${x.userName} `})
      //     else
      //       this.commentForm.patchValue( { postId : this.post!.id,parentId : null,content : ''})
      //   }
      // );

    }
  }

  publishComment(){
    this.store.dispatch(CommentActions.addComment({comment : this.commentForm.value as AddComment}));
    if(this.commentForm.value.postId) this.postCommentCountVector.emit(1);
    if(this.post)
      this.commentForm.patchValue( { postId : this.post.id,parentId : null,content : ''})
  }

  ngOnDestroy(): void {
    this.respondedCommentSubscription?.unsubscribe()
  }
}
