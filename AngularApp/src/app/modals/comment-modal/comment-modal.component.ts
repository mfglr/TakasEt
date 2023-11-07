import { Component, Input, OnChanges, OnDestroy } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store} from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import * as UserSelector from "src/app/states/user/selector"
import { Observable, Subscription } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserState } from 'src/app/states/user/state';
import { AppCommentState } from 'src/app/states/comment_state/state';
import * as appCommentSelectors from 'src/app/states/comment_state/selectors';
import * as appCommentActions from 'src/app/states/comment_state/actions';
@Component({
  selector: 'app-comment-modal',
  templateUrl: './comment-modal.component.html',
  styleUrls: ['./comment-modal.component.scss']
})
export class CommentModalComponent implements OnChanges, OnDestroy {
  @Input() post? : PostResponse;

  comments$? : Observable<CommentResponse[]>;

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
    private commentStore : Store<AppCommentState>
  ) {}

  ngOnChanges() {
    if(this.post){
      this.commentForm.patchValue({
          postId : this.post.id,
          userId : this.userId
      })
      this.comments$ = this.commentStore.select(appCommentSelectors.selectResponses({postId : this.post.id}))
    }
  }
  shareComment(){
  }
  getMore(){
    if(this.post){
      this.commentStore.dispatch(appCommentActions.nextPageAction({postId : this.post.id}))

    }
  }

  ngOnDestroy(): void {
    this.respondedCommentSubscription?.unsubscribe()
  }
}
