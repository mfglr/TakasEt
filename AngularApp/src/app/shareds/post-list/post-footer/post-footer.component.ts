import { AfterContentInit, Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
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

  constructor(
    public userPostLikingService : UserPostLikingService,
  ) {}

  displayComments(){
    if(this.post)
      this.displayCommentsEvent.emit(this.post)
  }
  
  getLikeVector(likeVector : number){
    if(this.post) this.post.countOfLikes += likeVector;
  }

}
