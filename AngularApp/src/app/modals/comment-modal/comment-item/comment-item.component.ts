import { Component, Input }  from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { takeValueOfComments } from 'src/app/states/app-states';
import { nextPageOfChildren } from 'src/app/states/comment_state/actions';
import { selectCommentResponses } from 'src/app/states/comment_state/selectors';
import { AppCommentState, commentsOfCommentQueryId } from 'src/app/states/comment_state/state';

@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent {
  @Input() comment? : CommentResponse;
  private queryId? : string; 
  children$? : Observable<CommentResponse[]>;
  remainingChildren : number = 0;
  childrenVisibility : boolean = true;
  constructor(
    public commentLikingService : UserCommentLikingService,
    private commentStore : Store<AppCommentState>
  ) {}

  ngOnChanges(){
    if(this.comment){
      this.queryId = commentsOfCommentQueryId + this.comment.id;
      this.children$ = this.commentStore.select(selectCommentResponses({queryId : this.queryId}));
      this.remainingChildren = this.comment.countOfChildren;
    }
  }
  lodChildren(){
    if(this.comment && this.queryId){
      this.commentStore.dispatch(nextPageOfChildren({queryId : this.queryId,commentId : this.comment.id}));
      this.remainingChildren = this.remainingChildren - takeValueOfComments;
    }
  }
  hiddenChildren(){
    this.childrenVisibility = false;
  }
  showChildren(){
    this.childrenVisibility = true;
  }
  
}
