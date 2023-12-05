import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, filter, mergeMap } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadPostImageAction } from 'src/app/states/post-image-state/actions';
import { PostImageState } from 'src/app/states/post-image-state/reducer';
import { selectPostImageState } from 'src/app/states/post-image-state/selectors';
import { PostState } from 'src/app/states/post-state/reducer';
import { selectPostResponse } from 'src/app/states/post-state/selectors';

@Component({
  selector: 'app-abstract-post',
  templateUrl: './abstract-post.component.html',
  styleUrls: ['./abstract-post.component.scss'],
})
export class AbstractPostComponent  implements OnInit {

  @Input() postId? : number;
  
  post$? : Observable<PostResponse | undefined>;
  postImageState$? : Observable<PostImageState | undefined>

  constructor(
    private postStore : Store<PostState>,
    private postImageStore : Store<PostImageState>
  ) { }

  ngOnInit() {
    
    if(this.postId){
      this.post$ = this.postStore.select(selectPostResponse({postId : this.postId}))
      
      this.postImageState$ = this.post$.pipe(
        filter(post => post != undefined),
        mergeMap(
          post => {
            let firstImageId = post!.postImages[0].id;
            this.postImageStore.dispatch(loadPostImageAction({id : firstImageId}))
            return this.postImageStore.select(selectPostImageState({id : firstImageId}))
          }
        )
      )
    }

  }

}
