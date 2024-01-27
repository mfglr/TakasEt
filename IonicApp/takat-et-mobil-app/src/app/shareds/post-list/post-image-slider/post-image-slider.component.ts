import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/state/reducer';
import { loadPostImageUrlAction } from 'src/app/state/actions';



@Component({
  selector: 'app-post-image-slider',
  templateUrl: './post-image-slider.component.html',
  styleUrls: ['./post-image-slider.component.scss'],
})
export class PostImageSliderComponent  implements OnInit {
  @Input() post? : PostResponse | null;
  @Output() displayPostDetailEvent = new EventEmitter<PostResponse>();


  constructor(
    private appStore : Store<AppState>
  ) { }

  ngOnInit() {
    if(this.post && this.post.postImages){
      this.appStore.dispatch(loadPostImageUrlAction({id : this.post.postImages[0].id}))
    }
  }

  loadImage(e : any) {
    if(this.post && this.post.postImages){
      let index = (e.detail[0].activeIndex + 1) % this.post.postImages.length;
      this.appStore.dispatch(loadPostImageUrlAction({id : this.post.postImages[index].id}))
    }
  }

  displayPostDetail(){
    if(this.post){
      this.displayPostDetailEvent.emit(this.post)
    }
  }
}
