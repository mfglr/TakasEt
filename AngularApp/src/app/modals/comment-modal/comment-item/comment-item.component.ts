import { Component, Input }  from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { nextPageOfChildren } from 'src/app/states/comment_state/actions';
import * as appCommentSelectors from 'src/app/states/comment_state/selectors';
import * as appCommentState from 'src/app/states/comment_state/state';
import * as appCommentActions from 'src/app/states/comment_state/actions'
@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent {
  @Input() comment? : CommentResponse;
  private queryId? : string;
  
  children$? : Observable<CommentResponse[]>;
  subsOfRemaining? : Subscription ;
  childrenVisibility$? : Observable<boolean>;
  
  remainingChildrenCount : number = 0;

  constructor(
    public commentLikingService : UserCommentLikingService,
    private commentStore : Store<appCommentState.AppCommentState>
  ) {}

  ngOnChanges(){
    if(this.comment){
      this.queryId = appCommentState.commentsOfCommentQueryId + this.comment.id;
      this.children$ = this.commentStore.select(appCommentSelectors.selectCommentResponses({queryId : this.queryId}));
      
      this.subsOfRemaining = this.commentStore.select(
        appCommentSelectors.selectRemainingChildrenCount({queryId : this.queryId, parentCommetId : this.comment.id})
      ).subscribe( x => this.remainingChildrenCount = x);

      this.childrenVisibility$ = this.commentStore.select(
        appCommentSelectors.selectChildrenVisibility({queryId : this.queryId , parentCommetId : this.comment.id})
      )
    }
  }
  lodChildren(){
    if(this.comment && this.queryId)
      this.commentStore.dispatch(nextPageOfChildren({queryId : this.queryId,commentId : this.comment.id}));
  }
  hiddenChildren(){
    if(this.comment && this.queryId)
      this.commentStore.dispatch(
        appCommentActions.switchChildrenVisibility({queryId : this.queryId,parentCommentId : this.comment.id})
      )
  }
  showChildren(){
    if(this.comment && this.queryId)
      this.commentStore.dispatch(
        appCommentActions.switchChildrenVisibility({queryId : this.queryId,parentCommentId : this.comment.id})
      )
  }
  
}
