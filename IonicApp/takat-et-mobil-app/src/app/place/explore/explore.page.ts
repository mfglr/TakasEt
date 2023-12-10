import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { State } from './state/reducer';
import { initPageState, nextPageAction } from './state/actions';
import { Observable } from 'rxjs';
import { selectPostIds } from './state/selectors';

@Component({
  selector: 'app-explore',
  templateUrl: './explore.page.html',
  styleUrls: ['./explore.page.scss'],
})
export class ExplorePage implements OnInit {

  @Input() initialPost? : PostResponse;
  postIds$?: Observable<number[] | undefined>

  constructor(
    private explorePageStore : Store<State>
  ) {}

  ngOnInit(){
    if(this.initialPost){
      this.explorePageStore.dispatch(initPageState({post : this.initialPost}));
      this.explorePageStore.dispatch(nextPageAction({postId : this.initialPost.id}));
      this.postIds$ = this.explorePageStore.select(selectPostIds({postId : this.initialPost.id}));
    }
  }
}
