import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostListState } from '../state/reducer';
import { openModalAction } from '../state/actions';
import { Observable } from 'rxjs';
import { PostState } from 'src/app/states/post-state/reducer';
import { selectPostResponse } from 'src/app/states/post-state/selectors';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent{

  @Input() postId? : number;
  post$? : Observable<PostResponse | undefined>;

  constructor(
    private postListStore : Store<PostListState>,
    private postStore : Store<PostState>
  ) {}

  ngOnInit(){
    if(this.postId){
      this.post$ = this.postStore.select(selectPostResponse({postId : this.postId}))
    }
  }

  displayPostDetail(post : PostResponse){
    this.postListStore.dispatch(openModalAction({post : post}))
  }

  loadContent(post : PostResponse){
      this.postListStore.dispatch(openModalAction({post : post}))
  }

}
