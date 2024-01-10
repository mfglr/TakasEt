import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { FilterPostsPageState } from './state/reducer';
import { filterPostsByCategoryIdsAction, filterPostsByKeyAction } from './state/actions';
import { selectPostIds } from './state/selectors';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.page.html',
  styleUrls: ['./filter.page.scss'],
})
export class FilterPage implements OnInit {

  postIds$ = this.filterPostPageStore.select(selectPostIds);

  constructor(
    private filterPostPageStore : Store<FilterPostsPageState>
  ) { }

  ngOnInit() {
  }

  onKeyChange(key : string | undefined){
    this.filterPostPageStore.dispatch(filterPostsByKeyAction({key : key}))
  }

  onCategoryIdChange(categoryIds : string | undefined){
    this.filterPostPageStore.dispatch(filterPostsByCategoryIdsAction({categoryIds : categoryIds}))
  }
}
