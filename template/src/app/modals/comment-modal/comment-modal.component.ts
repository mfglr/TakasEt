import { Component, EventEmitter, Input, OnChanges, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import * as UserSelector from "src/app/states/user/selector"
import { Observable, Subscription, filter } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserState } from 'src/app/states/user/state';
import { HomeState } from 'src/app/states/home/reducer';
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
  comments$? : Observable<CommentResponse[]>
  cancelRespondingComment(){
  }


  commentForm = new FormGroup({
    parentId : new FormControl<string | undefined>(undefined),
    postId : new FormControl<string | undefined>(undefined),
    userId : new FormControl<string>(''),
    content : new FormControl<string>('')
  });

  constructor(
    private userStore : Store<UserState>,
    private homeStore : Store<HomeState>
  ) {}


  getMore(){
  }
  ngOnChanges() {
    if(this.post){


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
