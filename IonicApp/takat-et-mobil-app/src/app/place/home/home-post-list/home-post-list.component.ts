import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { nextPageAction } from 'src/app/states/post-state/actions';
import { selectPostResponses } from 'src/app/states/post-state/selectors';
import { PagePostState, homePagePostList } from 'src/app/states/post-state/state';

@Component({
  selector: 'home-post-list',
  templateUrl: './home-post-list.component.html',
  styleUrls: ['./home-post-list.component.scss'],
})
export class HomePostListComponent  implements OnInit {

  homePagePostList = homePagePostList;

  posts$ = this.pagePostStore.select(selectPostResponses({pageId : homePagePostList}))

  constructor(
    private pagePostStore : Store<PagePostState>
  ) { }

  ngOnInit() {
    this.pagePostStore.dispatch(nextPageAction({pageId : homePagePostList}))
  }

}
