import { Component, Input, OnDestroy } from '@angular/core';
import { GenericMode } from 'src/app/helpers/generic-mode';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';

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
  ) {}

  switchChildrenVisibility(){
    this.mode.next()?.call(this);
  }

  showChildren(){
    this.childrenVisibility = true;

  }

  hideChildren(){
    this.childrenVisibility = false;
  }

  commentToParent(){
  }

  ngOnDestroy(): void {
  }
}
