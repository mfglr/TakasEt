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
  @Output() displayCommentsEvent = new EventEmitter<PostResponse>();
  @Output() displayPostLikersEvent = new EventEmitter<PostResponse>();
  @Output() displayPostViewersEvent = new EventEmitter<PostResponse>();

  constructor(
    public userPostLikingService : UserPostLikingService,
  ) {}

  getLikeVector(likeVector : number){
    if(this.post) this.post.countOfLikes += likeVector;
  }

  displayComments(){
    if(this.post)this.displayCommentsEvent.emit(this.post)
  }

  displayPostLikers(){
    if(this.post) this.displayPostLikersEvent.emit(this.post)
  }

  displayPostViewers(){
    if(this.post) this.displayPostViewersEvent.emit(this.post)
  }
}
