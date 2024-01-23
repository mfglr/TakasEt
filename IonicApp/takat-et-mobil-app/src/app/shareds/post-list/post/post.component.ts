import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostListState } from '../state/reducer';
import { openModalAction } from '../state/actions';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent{

  @Input() post? : PostResponse;

  constructor(
    private postListStore : Store<PostListState>,
  ) {}

  ngOnInit(){

  }

  displayPostDetail(post : PostResponse){
    this.postListStore.dispatch(openModalAction({post : post}))
  }

  loadContent(post : PostResponse){
      this.postListStore.dispatch(openModalAction({post : post}))
  }

}
