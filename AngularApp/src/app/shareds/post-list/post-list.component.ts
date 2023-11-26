import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { nextPageAction } from 'src/app/states/post-state/actions';
import { selectPostResponses } from 'src/app/states/post-state/selectors';
import { PagePostState } from 'src/app/states/post-state/state';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent {
  @Input() pageId? : string;
  posts$? : Observable<PostResponse[]>

  constructor(
    private pagePostStore : Store<PagePostState>
  ) {}

  ngOnInit(){
    if(this.pageId)
      this.pagePostStore.dispatch(nextPageAction({pageId : this.pageId}))
  }

  ngOnChanges(){
    if(this.pageId)
      this.posts$ = this.pagePostStore.select(selectPostResponses({pageId : this.pageId}))
  }

  getMore(){
    if(this.pageId)
      this.pagePostStore.dispatch(nextPageAction({pageId : this.pageId}))
  }
  
}
