import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Mode } from 'src/app/helpers/mode';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { getLoginResponse } from 'src/app/states/user/selector';
import { UserState } from 'src/app/states/user/state';

@Component({
  selector: 'app-comment-item-content',
  templateUrl: './comment-item-content.component.html',
  styleUrls: ['./comment-item-content.component.scss']
})
export class CommentItemContentComponent {
  @Input() hasChildren : boolean = true;
  @Input() comment? : CommentResponse;
  
  user$ = this.userStore.select(getLoginResponse)

  constructor(
    public commentLikingService : UserCommentLikingService,
    private userStore : Store<UserState>
  ) {}


}
