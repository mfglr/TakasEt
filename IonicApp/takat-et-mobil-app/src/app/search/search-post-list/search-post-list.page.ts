import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { EntitySearchPostListPageState } from './state/reducer';
import { Observable, Subscription, first, map, mergeMap } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { selectPostIds, selectPosts } from './state/selectors';
import { initSearchPostListPageStateAction, nextPostsAction } from './state/actions';

@Component({
  selector: 'app-search-post-list',
  templateUrl: './search-post-list.page.html',
  styleUrls: ['./search-post-list.page.scss'],
})
export class SearchPostListPage implements OnInit {

  postId$? : Observable<number>;
  postIds$? : Observable<number[] | undefined>
  initializer? : Subscription;
  constructor(
    private entitySearchPostListPageStore: Store<EntitySearchPostListPageState>,
    private activatedRoute : ActivatedRoute
  ) { }

  ngOnInit() {
    this.postId$ = this.activatedRoute.paramMap.pipe(
      map(x => parseInt(x.get("postId")!))
    )

    this.postIds$ = this.postId$.pipe(
      mergeMap(
        postId => this.entitySearchPostListPageStore.select(selectPostIds({postId : postId}))
      )
    )

    this.initializer = this.postId$.pipe(
      mergeMap(
        postId => this.postIds$!.pipe(
          first(),
          map(
            postIds => {
              if(!postIds){
                this.entitySearchPostListPageStore.dispatch(initSearchPostListPageStateAction({postId : postId}))
                this.entitySearchPostListPageStore.dispatch(nextPostsAction({postId : postId}))
              }
              else{
                if(postIds.length == 0)
                  this.entitySearchPostListPageStore.dispatch(nextPostsAction({postId : postId}))
              }
            }
          )
        )
      )
    ).subscribe();
  }


  nextPage(){
    this.postId$?.pipe(first()).subscribe(
      postId =>
      this.entitySearchPostListPageStore.dispatch(nextPostsAction({postId : postId}))
    )
  }

  ngOnDestroy(){
    this.initializer?.unsubscribe();
  }


}
