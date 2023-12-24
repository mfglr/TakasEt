import { Component, OnInit } from '@angular/core';
import { HomePageState } from './state/reducer';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { nextPostsAction } from './state/actions';
import { selectIsLastEntities, selectPostIds } from './state/selectors';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  postIds$? : Observable<number[]>;
  isLastEntities$ = this.homePageStore.select(selectIsLastEntities);

  constructor(
    private homePageStore : Store<HomePageState>,
  ) { }

  ngOnInit() {
    this.postIds$ = this.homePageStore.select(selectPostIds);
    this.homePageStore.dispatch(nextPostsAction())
  }

  nextPage(){
    this.homePageStore.dispatch(nextPostsAction());
  }

}
