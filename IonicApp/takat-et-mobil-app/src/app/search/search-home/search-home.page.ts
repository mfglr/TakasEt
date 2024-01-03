import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { SearchHomePageState } from './state/reducer';
import { selectPostIds } from './state/selector';
import { first } from 'rxjs';
import { nextPostsAction, searchPostsAction } from './state/action';

@Component({
  selector: 'app-search-home',
  templateUrl: './search-home.page.html',
  styleUrls: ['./search-home.page.scss'],
})
export class SearchHomePage implements OnInit {

  tags = [
    {name : "posts", icon : undefined},
    {name : "users", icon : undefined}
  ]

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

  onKeyChange(key : string){
    this.searchHomePageStore.dispatch(searchPostsAction({key : key}))
  }
  onActiveIndexChange(e : any){
    console.log(e.detail[0].activeIndex);
  }
}
