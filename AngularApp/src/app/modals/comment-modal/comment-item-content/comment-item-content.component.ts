import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { Mode } from 'src/app/helpers/mode';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { AppLoginState } from 'src/app/states/login_state/state';
import { setAction } from 'src/app/states/replied_comment_state/actions';
import { RepliedCommentState } from 'src/app/states/replied_comment_state/state';

@Component({
  selector: 'app-comment-item-content',
  templateUrl: './comment-item-content.component.html',
  styleUrls: ['./comment-item-content.component.scss']
})
export class CommentItemContentComponent {
  @Input() parentComment : CommentResponse | undefined = undefined;
  @Input() hasChildren : boolean = true;
  @Input() comment? : CommentResponse;
  @Input() diameter : string = '50';

  userId$ = this.loginStore.select(selectUserId)

  constructor(
    public commentLikingService : UserCommentLikingService,
    private loginStore : Store<AppLoginState>,
    private repliedCommentStore : Store<RepliedCommentState>
  ) {}

  replyComment(){
    if(this.comment)
      this.repliedCommentStore.dispatch(
        setAction({userName : this.comment.userName, comment : this.comment,parentComment : this.parentComment})
      )
  }
}
