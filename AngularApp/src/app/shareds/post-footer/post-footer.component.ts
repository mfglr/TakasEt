import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { UserPostLikingService } from 'src/app/services/user-post-liking.service';
import { setSelectedPostId } from 'src/app/states/home-page/actions';
import { HomePageState } from 'src/app/states/home-page/reducer';

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
    private store : Store<HomePageState>
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
