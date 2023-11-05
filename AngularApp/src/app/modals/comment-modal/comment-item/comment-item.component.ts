import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Mode } from 'src/app/helpers/mode';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { takeValueOfComments } from 'src/app/states/app_state/app-states';

@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent {
  @Input() comment? : CommentResponse;
  @Output() nextPageOfChildrenEvent = new EventEmitter<void>();
  @Output() setSelectedCommentEvent = new EventEmitter<CommentResponse>();

  remainingChildCommentCounts = 0;
  mode : Mode = new Mode(2)

  constructor(
    public commentLikingService : UserCommentLikingService,
  ) {}


  ngOnChanges(){
  }

  loadChildren(){
  }
  hover(){
  }

  commentToParent(){
  }
}
