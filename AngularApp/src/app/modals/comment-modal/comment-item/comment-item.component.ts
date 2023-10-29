import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Mode } from 'src/app/helpers/mode';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { takeValueOfComments } from 'src/app/states/app-states';
import { nextPageOfChildren, setSelectedCommentId } from 'src/app/states/home-page/actions';
import { MappedCommentStateModel } from 'src/app/states/home-page/selectors/comments-selectors';

@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent {
  @Input() mappedComment? : MappedCommentStateModel;
  @Input() comment? : CommentResponse;
  @Output() nextPageOfChildrenEvent = new EventEmitter<void>();
  @Output() setSelectedCommentEvent = new EventEmitter<CommentResponse>();

  remainingChildCommentCounts = 0;
  mode : Mode = new Mode(2)

  constructor(
    public commentLikingService : UserCommentLikingService,
  ) {}


  ngOnChanges(){
    if(this.mappedComment && this.mappedComment.comment.countOfChildren > 0){
      this.remainingChildCommentCounts = this.mappedComment.comment.countOfChildren - this.mappedComment.children!.length
    }
  }

  loadChildren(){
    if(this.mappedComment && this.mappedComment.comment.countOfChildren > 0){
      this.nextPageOfChildrenEvent.emit();
      this.remainingChildCommentCounts = this.remainingChildCommentCounts - takeValueOfComments;
      this.mode = new Mode(2,1);
    }
  }
  hover(){
    if(this.mappedComment)
      this.setSelectedCommentEvent.emit(this.mappedComment.comment);
  }

  commentToParent(){
  }
}
