import { Component, Input } from '@angular/core';
import { Mode } from 'src/app/helpers/mode';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { MappedCommentStateModel } from 'src/app/states/home-page/selectors/comments-selectors';

@Component({
  selector: 'app-comment-item-content',
  templateUrl: './comment-item-content.component.html',
  styleUrls: ['./comment-item-content.component.scss']
})
export class CommentItemContentComponent {
  @Input() mappedComment? : MappedCommentStateModel;
  @Input() hasChildren : boolean = true;

  childrenVisibility = new Mode(2,0);

  displayedCountOfChildren = 0;

  constructor(
    public commentLikingService : UserCommentLikingService,
  ) {}

  ngOnChanges(){
    if(this.mappedComment) this.displayedCountOfChildren = this.mappedComment.comment.countOfChildren;
  }

  replyToComment(){

  }

}
