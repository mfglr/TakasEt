import { Component, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { FilterPostsPageState } from './state/reducer';
import { filterPostsByCategoryIdsAction, filterPostsByKeyAction, nextPostsAction } from './state/actions';
import { first } from 'rxjs';
import { IonContent } from '@ionic/angular';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.page.html',
  styleUrls: ['./filter.page.scss'],
})
export class FilterPage implements OnInit {

  @ViewChild(IonContent) content? : any;

  // postIds$ = this.filterPostPageStore.select(selectPostIds);

  endOfScroll? : number;

  constructor(
    private filterPostPageStore : Store<FilterPostsPageState>
  ) { }

  ngOnInit() {
    // this.postIds$.pipe(first()).subscribe(
    //   postIds => {
    //     if(postIds.length <= 0)
    //       this.filterPostPageStore.dispatch(nextPostsAction())
    //   }
    // )
  }

  ngAfterViewChecked(){
    if(this.content){
      let children = this.content.el.children;
      this.endOfScroll = children[0].offsetHeight + children[1].offsetHeight - this.content.el.clientHeight
    }
  }

  onScroll(e : CustomEvent){
    if(this.endOfScroll){
      let scrollTop = Math.round(e.detail.scrollTop);
      if(scrollTop >= this.endOfScroll - 10)
        this.filterPostPageStore.dispatch(nextPostsAction());
    }
  }

  onKeyChange(key : string | undefined){
    this.filterPostPageStore.dispatch(filterPostsByKeyAction({key : key}))
  }

  onCategoryIdChange(categoryIds : string | undefined){
    this.filterPostPageStore.dispatch(filterPostsByCategoryIdsAction({categoryIds : categoryIds}))
  }
}
