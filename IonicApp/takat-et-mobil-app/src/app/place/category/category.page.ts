import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { CategoryPageCollectionState } from './state/reducer';
import { ActivatedRoute } from '@angular/router';
import { Observable, first, map, mergeMap } from 'rxjs';
import { selectPostIds } from './state/selectors';
import { initCategoryPageState, nextPostsAction } from './state/actions';

@Component({
  selector: 'app-category',
  templateUrl: './category.page.html',
  styleUrls: ['./category.page.scss'],
})
export class CategoryPage implements OnInit {

  categoryId$? : Observable<number>
  postsIds$? : Observable<number[] | undefined>

  constructor(
    private categoryPageCollectionStore : Store<CategoryPageCollectionState>,
    private activatedRoute : ActivatedRoute
  ) { }

  ngOnInit() {
    this.categoryId$ = this.activatedRoute.paramMap.pipe(
      map(x => parseInt(x.get("categoryId")!))
    )
    this.postsIds$ = this.categoryId$.pipe(
      mergeMap(
        categoryId => this.categoryPageCollectionStore.select(selectPostIds({categoryId : categoryId}))
      )
    )

    this.categoryId$.pipe(
      mergeMap(categoryId => this.postsIds$!.pipe(
        first(),
        map(postIds => {
          this.categoryPageCollectionStore.dispatch(initCategoryPageState({categoryId : categoryId}));
          if(!postIds || !postIds.length)
            this.categoryPageCollectionStore.dispatch(nextPostsAction({categoryId : categoryId}))
        })
      )),
    ).subscribe()



  }

}
