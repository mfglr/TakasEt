import { Component, Input }  from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { nextPageOfChildren, switchVisibilityAction } from 'src/app/states/comment_modal_state/action';
import { selectChildComments, selectChildrenRemainingCount, selectDisplayedChildrenCount, selectVisibility } from 'src/app/states/comment_modal_state/selector';
import { CommentModalState } from 'src/app/states/comment_modal_state/state';

@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent {
  @Input() comment? : CommentResponse;
  @Input() postId? : number;
  children$? : Observable<CommentResponse[]>;
  childrenVisibility$? : Observable<boolean>;
  displayedCount$? : Observable<number>;
  subsRemainingChildrenCount? : Subscription;
  remainingChildrenCount : number = 0;

  constructor(
    public commentLikingService : UserCommentLikingService,
    private commentModalStore : Store<CommentModalState>
  ) {}

  ngOnChanges(){
    if(this.comment && this.postId){

      this.children$ = this.commentModalStore.select(
        selectChildComments({postId : this.postId,commentId : this.comment.id})
      );
      
      this.childrenVisibility$ = this.commentModalStore.select(
        selectVisibility({postId : this.postId,commentId : this.comment.id})
      )
      
      this.displayedCount$ = this.commentModalStore.select(
        selectDisplayedChildrenCount({postId : this.postId,commentId : this.comment.id})
      )
      
      this.subsRemainingChildrenCount = this.commentModalStore.select(
        selectChildrenRemainingCount({postId : this.postId,commentId : this.comment.id})
      ).subscribe(x => this.remainingChildrenCount = x);

    }
  }
  
  loadChildren(){
    if(this.comment && this.postId){
      this.commentModalStore.dispatch(nextPageOfChildren({postId : this.postId,commentId : this.comment.id}));
    }
  }

  hiddenChildren(){
    if(this.comment && this.postId){
      this.commentModalStore.dispatch(switchVisibilityAction({postId : this.postId,commentId : this.comment.id}))
    }
  }
  showChildren(){
    if(this.comment && this.postId){
      this.commentModalStore.dispatch(switchVisibilityAction({postId : this.postId,commentId : this.comment.id}))
    }
  }
  ngOnDestroy(){
    this.subsRemainingChildrenCount?.unsubscribe();
  }
}
