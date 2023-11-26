import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadNextPostImageAction, loadPostImageAction } from 'src/app/states/post-state/actions';
import { PagePostState, homePagePostList } from 'src/app/states/post-state/state';

@Component({
  selector: 'app-post-image-slider',
  templateUrl: './post-image-slider.component.html',
  styleUrls: ['./post-image-slider.component.scss'],
})
export class PostImageSliderComponent  implements OnInit {
  @Input() post? : PostResponse;
  @Input() urls? : string[] | null;
  homePagePostList = homePagePostList;
  constructor(
    private pagePostStore : Store<PagePostState>
  ) { }

  ngOnInit() {}

  onSlidechangetransitionstart(){
    if(this.post)
      this.pagePostStore.dispatch(loadNextPostImageAction({pageId : homePagePostList,postId : this.post.id}))
  }
}
