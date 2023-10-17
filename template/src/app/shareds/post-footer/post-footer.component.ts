import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';
import { UserPostLikingService } from 'src/app/services/user-post-liking.service';

@Component({
  selector: 'app-post-footer',
  templateUrl: './post-footer.component.html',
  styleUrls: ['./post-footer.component.scss']
})
export class PostFooterComponent {

  @Input() post? : PostResponse;
  @Output() commentButtonEvent = new EventEmitter<PostResponse>();

  constructor(
    public userPostLikingService : UserPostLikingService,
  ) {}

  getLikeVector(likeVector : number){
    if(this.post) this.post.countOfLikes += likeVector;
  }

  emitCommentButtonEvent(){
    if(this.post)this.commentButtonEvent.emit(this.post)
  }

}
