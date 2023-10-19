import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { UserPostLikingService } from 'src/app/services/user-post-liking.service';
import { setSelectedPostId } from 'src/app/states/home/actions';
import { HomeState } from 'src/app/states/home/reducer';

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
    private store : Store<HomeState>
  ) {}


  hover(){
    if(this.post)
      this.store.dispatch(setSelectedPostId({ postId : this.post.id }))
  }

  getLikeVector(likeVector : number){
    if(this.post) this.post.countOfLikes += likeVector;
  }

  displayCommentsButton(){
    if(this.post)this.commentButtonEvent.emit(this.post)
  }

}
