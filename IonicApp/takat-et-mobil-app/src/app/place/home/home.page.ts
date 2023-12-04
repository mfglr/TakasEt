import { Component, OnInit } from '@angular/core';
import { HomePageState } from './state/reducer';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { selectPostResponses } from './state/selectors';
import { nextPageAction } from './state/actions';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  posts$? : Observable<PostResponse[]>;

  constructor(
    private homePageStore : Store<HomePageState>
  ) { }

  ngOnInit() {
    this.posts$ = this.homePageStore.select(selectPostResponses);
    this.homePageStore.dispatch(nextPageAction())
  }

}
