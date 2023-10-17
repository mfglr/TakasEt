import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';

@Component({
  selector: 'app-comment-item-content',
  templateUrl: './comment-item-content.component.html',
  styleUrls: ['./comment-item-content.component.scss']
})
export class CommentItemContentComponent {
  @Input() comment? : CommentResponse;

  constructor(
    public commentLikingService : UserCommentLikingService
  ) {}

}
