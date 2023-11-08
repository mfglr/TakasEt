import { Component, EventEmitter, Input, Output }  from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import * as appChildCommentSelectors from 'src/app/states/child_comment_state/selectors';
import * as appChildCommentActions from 'src/app/states/child_comment_state/actions';
import { AppChildCommentState } from 'src/app/states/child_comment_state/state';

@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent {
  @Input() comment? : CommentResponse;
  children$? : Observable<CommentResponse[]>;
  childrenVisibility$? : Observable<boolean>;
  displayedCount$? : Observable<number>;
  subsRemainingChildrenCount? : Subscription;
  remainingChildrenCount : number = 0;

  constructor(
    public commentLikingService : UserCommentLikingService,
    private commentStore : Store<AppChildCommentState>
  ) {}

  ngOnChanges(){
    if(this.comment){

      this.children$ = this.commentStore.select(
        appChildCommentSelectors.selectResponses({parentComment : this.comment})
      );
      
      this.childrenVisibility$ = this.commentStore.select(
        appChildCommentSelectors.selectVisibility({parentComment : this.comment})
      )
      
      this.displayedCount$ = this.commentStore.select(
        appChildCommentSelectors.selectDisplayedCount({parentComment : this.comment})
      )
      
      this.subsRemainingChildrenCount = this.commentStore.select(
        appChildCommentSelectors.selectRemainingCount({parentComment : this.comment})
      ).subscribe(x => this.remainingChildrenCount = x);

    }
  }
  
  loadChildren(){
    if(this.comment){
      this.commentStore.dispatch(appChildCommentActions.nextPageAction({parentComment : this.comment}));
    }
  }

  hiddenChildren(){
    if(this.comment){
      this.commentStore.dispatch(appChildCommentActions.switchVisibilityAction({parentComentId : this.comment.id}))
    }
  }
  showChildren(){
    if(this.comment){
      this.commentStore.dispatch(appChildCommentActions.switchVisibilityAction({parentComentId : this.comment.id}))
    }
  }
  ngOnDestroy(){
    this.subsRemainingChildrenCount?.unsubscribe();
  }
}
