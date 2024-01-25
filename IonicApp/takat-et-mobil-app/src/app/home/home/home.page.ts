import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { HomePageState } from './state/reducer';
import { selectIsLastEntities, selectPostResponses, selectUser } from './state/selectors';
import { nextPostsAction } from './state/actions';
import { AppState } from 'src/app/states/reducer';
import { first } from 'rxjs';
import { loadUserAction } from 'src/app/states/actions';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  constructor(
    private homePageStore : Store<HomePageState>,
  ) { }

  posts$ = this.homePageStore.select(selectPostResponses);
  isLastEntities$ = this.homePageStore.select(selectIsLastEntities);

  ngOnInit() {
    this.homePageStore.dispatch(nextPostsAction())
  }

}
