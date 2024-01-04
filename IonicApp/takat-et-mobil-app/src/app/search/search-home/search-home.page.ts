import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { SearchHomePageState } from './state/reducer';
import { selectActiveIndex, selectPostIds, selectUserIds } from './state/selector';
import { changeActiveIndex, nextPostsAction, searchUsersAction } from './state/action';
import { first } from 'rxjs';
import { IonContent } from '@ionic/angular';

@Component({
  selector: 'app-search-home',
  templateUrl: './search-home.page.html',
  styleUrls: ['./search-home.page.scss'],
})
export class SearchHomePage implements OnInit {

  tags = [
    {name : "posts", icon : undefined},
    {name : "users", icon : undefined}
  ]

  @ViewChild(IonContent) content? : IonContent

  activeIndex$ = this.searchHomePageStore.select(selectActiveIndex);
  postIds$ = this.searchHomePageStore.select(selectPostIds);
  userIds$ = this.searchHomePageStore.select(selectUserIds);
  constructor(
    private searchHomePageStore : Store<SearchHomePageState>
  ) { }

  ngOnInit() {
    this.postIds$.pipe(
      first()
    ).subscribe(postIds => {
      if(postIds.length == 0) this.searchHomePageStore.dispatch(nextPostsAction())
    })
  }

  onKeyChange(key : string){
    this.searchHomePageStore.dispatch(searchUsersAction({ key : key }))
  }

  onActiveIndexChange(e : any){
    this.searchHomePageStore.dispatch(changeActiveIndex({activeIndex : e.detail[0].activeIndex}));
  }

  async onScroll(event : any){

    if(this.content){
      const scrollElement = await this.content.getScrollElement();
      const scrollTop = event.detail.scrollTop;
    }


  }


}
