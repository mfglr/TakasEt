import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadPostImage, setCurrentIndex } from 'src/app/states/home_page_state/actions';
import { selectCurrentIndex, selectUrls } from 'src/app/states/home_page_state/selectors';
import { HomePageState } from 'src/app/states/home_page_state/state';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnChanges {
  @Input() post? : PostResponse;
  @Output() diplayCommentsEvent = new EventEmitter<PostResponse>();
  
  urls$?: Observable<string[]>
  currentIndex$? : Observable<number>

  constructor(
    private homePageStore : Store<HomePageState>
  ) {}

  ngOnChanges(changes: SimpleChanges): void {
    if(this.post){
      this.urls$ = this.homePageStore.select(selectUrls({postId : this.post.id}));
      this.currentIndex$ = this.homePageStore.select(selectCurrentIndex({postId : this.post.id}))
    }
  }
  displayComments(post : PostResponse){
    if(this.post)
      this.diplayCommentsEvent.emit(this.post)
  }
  setCurrentIndex(index : number){
    if(this.post)
      this.homePageStore.dispatch(setCurrentIndex({postId : this.post.id, index : index}))
  }
  loadImage(index : number){
    if(this.post)
      this.homePageStore.dispatch(loadPostImage({postId : this.post.id, index : index}))
  }

}
