import { Component, Input} from '@angular/core';
import { Store } from '@ngrx/store';
import { CommentResponse } from 'src/app/models/responses/comment-response';
import { UserCommentLikingService } from 'src/app/services/user-comment-liking.service';
import { setCommentToReplyAction } from 'src/app/states/comment_modal_state/action';
import { CommentModalState } from 'src/app/states/comment_modal_state/state';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { AppLoginState } from 'src/app/states/login_state/state';

@Component({
  selector: 'app-comment-item-content',
  templateUrl: './comment-item-content.component.html',
  styleUrls: ['./comment-item-content.component.scss']
})
export class CommentItemContentComponent {
  @Input() postId? : number;
  @Input() ownerId? : number;
  @Input() hasChildren : boolean = true;
  @Input() comment? : CommentResponse;
  @Input() diameter : string = '50';

  userId$ = this.loginStore.select(selectUserId)

  constructor(
    public commentLikingService : UserCommentLikingService,
    private loginStore : Store<AppLoginState>,
    private commentModalStore : Store<CommentModalState>
  ) {}

  replyComment(){
    console.log(this.ownerId)
    console.log(this.comment)
    console.log(this.postId)
    if(this.ownerId && this.comment && this.postId){
      this.commentModalStore.dispatch(setCommentToReplyAction({
        postId : this.postId, ownerId : this.ownerId, ownerType : "comment",comment : this.comment
      }))
    }
  }
}
