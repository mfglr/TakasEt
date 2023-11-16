import { Component, ElementRef, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { PostResponse } from 'src/app/models/responses/post-response';
import { nextPageOfPosts } from 'src/app/states/home_page_state/actions';
import { HomePageState } from 'src/app/states/home_page_state/reducer';
import { selectPostResponses } from 'src/app/states/home_page_state/selectors';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  @ViewChild("displayPostModalButton",{static : true}) displayPostModalButton? : ElementRef;
  post$ = this.homePageStore.select(selectPostResponses)
  postWithCommentsDisplayed? : PostResponse;

  constructor(
    private homePageStore : Store<HomePageState>
  ) {}

  ngOnInit(){
    this.homePageStore.dispatch(nextPageOfPosts())
  }

  getNextPageOfPosts(){
    this.homePageStore.dispatch(nextPageOfPosts())
  }
}
