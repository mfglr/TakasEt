import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { UserPostLikingService } from 'src/app/services/user-post-liking.service';
import {  CommentModalStateCollection } from 'src/app/states/comment_modal_state/state';
@Component({
  selector: 'home-post-footer',
  templateUrl: './post-footer.component.html',
  styleUrls: ['./post-footer.component.scss']
})
export class HomePostFooterComponent {

  @Input() post? : PostResponse;
  @Output() displayCommentsEvent = new EventEmitter<PostResponse>();

  constructor(
    public userPostLikingService : UserPostLikingService,
    private commentModalStore : Store<CommentModalStateCollection>
  ) {}

  displayComments(){
    if(this.post){
      this.displayCommentsEvent.emit(this.post)
    }
  }
  
  getLikeVector(likeVector : number){
    if(this.post) this.post.countOfLikes += likeVector;
  }

}
