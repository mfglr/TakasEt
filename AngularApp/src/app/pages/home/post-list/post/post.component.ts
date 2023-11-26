import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadPostImageAction, setCurrentIndexOfPostImagesAction } from 'src/app/states/post-state/actions';
import { selectCurrentPostImageIndex, selectUrls } from 'src/app/states/post-state/selectors';
import { PagePostState, homePagePostList } from 'src/app/states/post-state/state';

@Component({
  selector: 'home-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class HomePostComponent implements OnChanges {
  @Input() post? : PostResponse;
  @Output() diplayCommentsEvent = new EventEmitter<PostResponse>();
  
  urls$?: Observable<string[]>
  currentIndex$? : Observable<number>

  constructor(
    private pagePostStore : Store<PagePostState>
  ) {}

  ngOnChanges(changes: SimpleChanges): void {
    if(this.post){
      this.urls$ = this.pagePostStore.select(selectUrls({ pageId : homePagePostList,postId : this.post.id}));
      this.currentIndex$ = this.pagePostStore.select(selectCurrentPostImageIndex({
        pageId : homePagePostList,postId : this.post.id
      }))
    }
  }
  displayComments(post : PostResponse){
    if(this.post)
      this.diplayCommentsEvent.emit(this.post)
  }
  setCurrentIndex(index : number){
    if(this.post)
      this.pagePostStore.dispatch(setCurrentIndexOfPostImagesAction({
        pageId : homePagePostList,postId : this.post.id, index : index
      }))
  }
  loadImage(index : number){
    if(this.post)
      this.pagePostStore.dispatch(loadPostImageAction({
        pageId : homePagePostList,postId : this.post.id, index : index
      }))
  }

}
