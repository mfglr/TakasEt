import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable} from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadPostImageAction, loadProfileImageAction, switchLikeStatusAction} from 'src/app/states/post-state/actions';
import { selectProfileImage, selectUrls } from 'src/app/states/post-state/selectors';
import { PagePostState, homePagePostList } from 'src/app/states/post-state/state';

@Component({
  selector: 'home-post',
  templateUrl: './home-post.component.html',
  styleUrls: ['./home-post.component.scss'],
})
export class HomePostComponent {
  @Input() post? : PostResponse;

  homePagePostList = homePagePostList
  urls$? : Observable<string[]>
  profileImage$? : Observable<string>
  
  constructor(
    private pagePostStore : Store<PagePostState>
  ) { }
  
  ngOnInit(){
    if(this.post){
      this.pagePostStore.dispatch(loadPostImageAction({pageId : homePagePostList,postId : this.post.id,index : 0}))
      this.pagePostStore.dispatch(loadProfileImageAction({pageId : homePagePostList,postId : this.post.id}))
      this.urls$ = this.pagePostStore.select(selectUrls({pageId : homePagePostList,postId : this.post.id}))
      this.profileImage$ = this.pagePostStore.select(selectProfileImage({pageId : homePagePostList,postId : this.post.id}))
    }
  }

  switchLikeStatus(){
    if(this.post)
      this.pagePostStore.dispatch(switchLikeStatusAction({pageId : homePagePostList,postId : this.post.id}))
  }
 
}
