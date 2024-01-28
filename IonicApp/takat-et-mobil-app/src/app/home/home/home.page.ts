import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { HomePageState } from './state/reducer';
import { selectIsLastEntities, selectPostResponses } from './state/selectors';
import { nextPostsAction } from './state/actions';
import { AppState } from 'src/app/state/reducer';
import { selectUserName } from 'src/app/state/selector';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  constructor(
    private homePageStore : Store<HomePageState>,
    private appStore : Store<AppState>
  ) { }

  userName$ = this.appStore.select(selectUserName);
  posts$ = this.homePageStore.select(selectPostResponses);
  isLastEntities$ = this.homePageStore.select(selectIsLastEntities);

  ngOnInit() {
    this.homePageStore.dispatch(nextPostsAction())
  }

}
