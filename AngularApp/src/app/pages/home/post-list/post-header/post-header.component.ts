import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { loadProfileImage } from 'src/app/states/home_page_state/actions';
import { selectProfileImage } from 'src/app/states/home_page_state/selectors';
import { HomePageState } from 'src/app/states/home_page_state/state';

@Component({
  selector: 'app-post-header',
  templateUrl: './post-header.component.html',
  styleUrls: ['./post-header.component.scss']
})
export class PostHeaderComponent {
  
  @Input() post? : PostResponse;
  
  profileImage$? : Observable<string>;

  constructor(
    private homePageStore : Store<HomePageState>
  ) {}

  ngOnInit(){
    if(this.post)
      this.homePageStore.dispatch(loadProfileImage({postId : this.post.id}))
  }

  ngOnChanges(){
    if(this.post)
      this.profileImage$ = this.homePageStore.select(selectProfileImage({postId : this.post.id}))
  }  
}
