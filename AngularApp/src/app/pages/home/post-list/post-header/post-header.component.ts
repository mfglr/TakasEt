import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadProfileImageAction } from 'src/app/states/post-state/actions';
import { selectProfileImage } from 'src/app/states/post-state/selectors';
import { PagePostState, homePagePostList } from 'src/app/states/post-state/state';

@Component({
  selector: 'home-post-header',
  templateUrl: './post-header.component.html',
  styleUrls: ['./post-header.component.scss']
})
export class HomePostHeaderComponent {
  
  @Input() post? : PostResponse;
  
  profileImage$? : Observable<string>;

  constructor(
    private pagePostStore : Store<PagePostState>
  ) {}

  ngOnInit(){
    if(this.post)
      this.pagePostStore.dispatch(loadProfileImageAction({ pageId : homePagePostList,postId : this.post.id}))
  }

  ngOnChanges(){
    if(this.post)
      this.profileImage$ = this.pagePostStore.select(selectProfileImage({ pageId : homePagePostList,postId : this.post.id}))
  }  
}
