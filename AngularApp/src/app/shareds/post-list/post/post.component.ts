import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadPostImageAction } from 'src/app/states/post-state/actions';
import { selectUrl } from 'src/app/states/post-state/selectors';
import { PagePostState } from 'src/app/states/post-state/state';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent {
  @Input() pageId? : string;
  @Input() post? : PostResponse;
  firstPostImage$? : Observable<string>;

  constructor(
    private pagePostStore : Store<PagePostState>
  ) { }

  ngOnInit(){
    if(this.pageId && this.post)
      this.pagePostStore.dispatch(loadPostImageAction({pageId : this.pageId,postId : this.post.id,index : 0}))
  }

  ngOnChanges(){
    if(this.pageId && this.post)
      this.firstPostImage$ = this.pagePostStore.select(selectUrl({pageId : this.pageId, postId : this.post.id,index : 0}))
  }

}
