import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import * as UserSelector from "src/app/states/user/selector"
import { Subscription } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserState } from 'src/app/states/user/state';
import { MappedCommentStateModel } from 'src/app/states/home-page/selectors/comments-selectors';

@Component({
  selector: 'app-comment-modal',
  templateUrl: './comment-modal.component.html',
  styleUrls: ['./comment-modal.component.scss']
})
export class CommentModalComponent implements OnChanges, OnDestroy {
  @Input() post? : PostResponse;
  @Input() mappedComments? : MappedCommentStateModel[] | null;
  @Output() nextPageOfCommentsEvent = new EventEmitter<void>();
  @Output() nextPageOfChildrenEvent = new EventEmitter<void>();
  @Output() setSelectedCommentEvent = new EventEmitter<CommentResponse>();

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
  ) {}

  getNextPageOfComments(){ this.nextPageOfCommentsEvent.emit(); }
  getNextPageOfChildren(){ this.nextPageOfChildrenEvent.emit(); }
  setSelectedComment(commentResponse : CommentResponse){ this.setSelectedCommentEvent.emit(commentResponse); }

  ngOnChanges() {
    if(this.post){
      this.commentForm.patchValue({
          postId : this.post.id,
          userId : this.userId
      })
    }
  }
  ngOnDestroy(): void {
    this.respondedCommentSubscription?.unsubscribe()
  }
}
