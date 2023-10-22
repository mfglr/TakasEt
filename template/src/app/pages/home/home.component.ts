import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, first, map } from 'rxjs';
import { nextPageOfPosts } from 'src/app/states/home-page/actions';
import { HomePageState } from 'src/app/states/home-page/reducer';
import { selectHomePageState, selectPostReponses } from 'src/app/states/home-page/selectors';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  posts$ = this.store.select(selectPostReponses)
  constructor(
    private store : Store<HomePageState>
  ) {}

  ngOnInit(): void {
    this.posts$.pipe(
      first(),
      filter( x => x.length <= 0),
      map(() => this.store.dispatch(nextPageOfPosts()) )
    ).subscribe();

    this.store.select(selectHomePageState).subscribe(x => console.log(x))
  }

  getMore(){
    this.store.dispatch(nextPageOfPosts())
  }

}
