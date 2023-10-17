import { Component, Input, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { GenericMode } from 'src/app/helpers/generic-mode';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { CommentState } from 'src/app/states/comment/reducer';
import * as CommentActions from 'src/app/states/comment/actions'
import * as CommentSelectors from 'src/app/states/comment/selector'
@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent implements OnDestroy {
  @Input() comment? : CommentResponse;
  childrenVisibility : boolean = false;
  mode : GenericMode<() => void> = new GenericMode([this.hideChildren,this.showChildren])

  constructor(
    public commentLikingService : UserCommentLikingService,
    private store : Store<CommentState>
  ) {}

  switchChildrenVisibility(){
    this.mode.next()?.call(this);
  }

  showChildren(){
    this.childrenVisibility = true;
    if(this.comment) this.store.dispatch(CommentActions.getCommentWithChildren({ parentId : this.comment.id}))

  }

  hideChildren(){
    this.childrenVisibility = false;
  }

  commentToParent(){
    if(this.comment)
      this.store.dispatch(CommentActions.setRespondedComment({ comment : this.comment}))

  }

  ngOnDestroy(): void {
  }
}
