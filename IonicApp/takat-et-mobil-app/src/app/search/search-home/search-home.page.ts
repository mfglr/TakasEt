import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { SearchHomePageState } from './state/reducer';
import { selectPostIds } from './state/selector';
import { first } from 'rxjs';
import { nextPostsAction } from './state/action';

@Component({
  selector: 'app-search-home',
  templateUrl: './search-home.page.html',
  styleUrls: ['./search-home.page.scss'],
})
export class SearchHomePage implements OnInit {

  clickedPostId? : number;

  postIds$ = this.searchHomePageStore.select(selectPostIds);

  constructor(
    private searchHomePageStore : Store<SearchHomePageState>
  ) { }

  ngOnInit() {
    this.postIds$.pipe(first()).subscribe(
      postIds => {
        if(postIds.length == 0)
          this.searchHomePageStore.dispatch(nextPostsAction());
      }
    )
  }

}
