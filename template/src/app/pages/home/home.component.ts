import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, first, map, mergeMap } from 'rxjs';
import { nextPageOfPosts } from 'src/app/states/home/actions';
import { selectPosts } from 'src/app/states/home/selectors';
import { HomeState } from 'src/app/states/home/states';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  posts$ = this.store.select(selectPosts)
  constructor(
    private store : Store<HomeState>
  ) {}

  ngOnInit(): void {
    this.posts$.pipe(
      first(),
      filter( x => x.length <= 0),
      map(() => this.store.dispatch(nextPageOfPosts()) )
    ).subscribe();
  }

  getMore(){
    this.store.dispatch(nextPageOfPosts())
  }

}
