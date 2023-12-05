import { Component, OnInit } from '@angular/core';
import { HomePageState } from './state/reducer';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { nextPageAction } from './state/actions';
import { selectPostIds } from './state/selectors';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  postIds$? : Observable<number[]>;

  constructor(
    private homePageStore : Store<HomePageState>,
  ) { }

  ngOnInit() {
    this.postIds$ = this.homePageStore.select(selectPostIds);
    this.homePageStore.dispatch(nextPageAction())
  }

}
