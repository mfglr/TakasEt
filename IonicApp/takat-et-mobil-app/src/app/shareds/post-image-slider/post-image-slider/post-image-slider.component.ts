import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostImageSliderState, PostImageState } from '../state/reducer';
import { Store } from '@ngrx/store';
import { initPostImageSliderAction,loadPostImageAction } from '../state/actions';
import { Observable } from 'rxjs';
import { selectPostImageStates } from '../state/selectors';
import { Event } from '@angular/router';



@Component({
  selector: 'app-post-image-slider',
  templateUrl: './post-image-slider.component.html',
  styleUrls: ['./post-image-slider.component.scss'],
})
export class PostImageSliderComponent  implements OnInit {
  @Input() post? : PostResponse | null;
  @Output() displayPostDetailEvent = new EventEmitter<PostResponse>();

  postImageStates$? : Observable<PostImageState[]>

  constructor(
    private sliderStore : Store<PostImageSliderState>
  ) { }

  ngOnInit() {
    if(this.post){
      this.sliderStore.dispatch(initPostImageSliderAction({post : this.post}))
      this.postImageStates$ = this.sliderStore.select(selectPostImageStates({postId : this.post.id}))
      this.sliderStore.dispatch(loadPostImageAction({postId : this.post.id,index : 0}))
    }
  }

  loadImage(e : any) {
    if(this.post){
      let index = (e.detail[0].activeIndex + 1) % this.post.postImages.length;
      this.sliderStore.dispatch(loadPostImageAction({postId : this.post.id,index : index}))
    }
  }

  displayPostDetail(){
    if(this.post){
      this.displayPostDetailEvent.emit(this.post)
    }
  }
}
