import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { State } from '../state/reducer';
import { openModalAction } from '../state/actions';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent{
  
  @Input() post? : PostResponse;


  constructor(
    private postListStore : Store<State>
  ) {}

  displayPostDetail(post : PostResponse){
    this.postListStore.dispatch(openModalAction({post : post}))
  }
  
  loadContent(){
    if(this.post)
      this.postListStore.dispatch(openModalAction({post : this.post}))
  }

}
