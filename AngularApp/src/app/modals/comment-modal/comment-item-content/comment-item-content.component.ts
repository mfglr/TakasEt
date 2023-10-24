import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Mode } from 'src/app/helpers/mode';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { HomePageState } from 'src/app/states/home-page/reducer';

@Component({
  selector: 'app-comment-item-content',
  templateUrl: './comment-item-content.component.html',
  styleUrls: ['./comment-item-content.component.scss']
})
export class CommentItemContentComponent {
  @Input() comment? : CommentResponse;
  @Input() hasChildren : boolean = true;
  childrenVisibility = new Mode(2,0);

  displayedCountOfChildren = 0;

  constructor(
    public commentLikingService : UserCommentLikingService,
    private homeStore : Store<HomePageState>
  ) {}

  ngOnChanges(){
    if(this.comment) this.displayedCountOfChildren = this.comment.countOfChildren;
  }

  replyToComment(){

  }

}
