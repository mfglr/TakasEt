import { Component, ElementRef, Input, OnChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store} from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { Observable, filter, fromEvent, map, withLatestFrom } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import * as commentModalState from 'src/app/states/comment_modal_state/state';
import * as commentModalSelectors from 'src/app/states/comment_modal_state/selector';
import * as commentModalActions from 'src/app/states/comment_modal_state/action';
@Component({
  selector: 'app-comment-modal',
  templateUrl: './comment-modal.component.html',
  styleUrls: ['./comment-modal.component.scss']
})
export class CommentModalComponent implements OnChanges {
  @Input() post? : PostResponse;
  @ViewChild("shareCommentButton",{static : true}) shareCommentButton? : ElementRef;
  
  comments$? : Observable<CommentResponse[]>;
  replyToCommentState$? : Observable<commentModalState.CommentToReplyState>

  commentForm = new FormGroup({
    content : new FormControl<string>('')
  });

  constructor(
    private commentModalStore : Store<commentModalState.CommentModalStateCollection>
  ) {}

  ngOnChanges() {
    if(this.post){
      this.comments$ = this.commentModalStore.select(
        commentModalSelectors.selectComments({postId : this.post.id})
      )
      this.replyToCommentState$ = this.commentModalStore.select(
        commentModalSelectors.selectCommentToReplyState({postId : this.post.id})
      )
    }
  }

  getMore(){
    if(this.post){
      this.commentModalStore.dispatch(commentModalActions.nextPageOfComments({postId : this.post.id}))
    }
  }

  resetCommentToReplyState(){
    if(this.post)
      this.commentModalStore.dispatch(commentModalActions.resetCommentToReplyAction({postId : this.post.id}));
  }

  shareComment(){
    if(this.post && this.commentForm.value.content)
      this.commentModalStore.dispatch(
        commentModalActions.shareComment({postId : this.post.id,content : this.commentForm.value.content})
      )
  }

}
