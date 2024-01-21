import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { SearchHomePageState } from './state/reducer';
import { selectActiveIndex } from './state/selector';
import { changeActiveIndex, nextPostsAction, nextUsersAction, searchUsersAction } from './state/action';
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

  @ViewChild("swiperContainer") swiperContainer? : ElementRef;
  @ViewChild(IonContent) content? : any;

  activeIndex$ = this.searchHomePageStore.select(selectActiveIndex);
  // postIds$ = this.searchHomePageStore.select(selectPostIds);
  // userIds$ = this.searchHomePageStore.select(selectUserIds);

  endOfPostsScroll? : number;
  endOfUsersScroll? : number;

  constructor(
    private searchHomePageStore : Store<SearchHomePageState>
  ) { }

  ngOnInit() {
    // this.postIds$.pipe(
    //   first()
    // ).subscribe(postIds => {
    //   if(postIds.length == 0) this.searchHomePageStore.dispatch(nextPostsAction())
    // })
  }

  ngAfterContentInit(){
    this.activeIndex$.pipe(first()).subscribe(x => {
      this.slideTo(x)
    })
  }

  onKeyChange(key : string){
    this.searchHomePageStore.dispatch(searchUsersAction({ key : key }))
  }

  slideTo(index : number){
    this.swiperContainer?.nativeElement.swiper.slideTo(index)
  }

  onActiveIndexChange(e : any){
    if(e instanceof CustomEvent)
      this.searchHomePageStore.dispatch(changeActiveIndex({activeIndex : e.detail[0].activeIndex}));
    else{
      this.searchHomePageStore.dispatch(changeActiveIndex({activeIndex : e}))
      this.slideTo(e)
    }
  }

  onScroll(event : CustomEvent){

    this.activeIndex$.pipe(first()).subscribe(
      activeIndex => {
        if(activeIndex == 0){
          if(this.endOfPostsScroll){
            let scrollTop = Math.round(event.detail.scrollTop);
            if(scrollTop >= this.endOfPostsScroll - 10){
              this.searchHomePageStore.dispatch(nextPostsAction())
            }
          }
        }
        else{
          if(this.endOfUsersScroll){
            let scrollTop = Math.round(event.detail.scrollTop);
            if(scrollTop >= this.endOfUsersScroll - 10){
              this.searchHomePageStore.dispatch(nextUsersAction())
            }
          }
        }
      }
    )


  }

  ngAfterViewChecked(){
    if(this.content){
      let children = this.content?.el.children;

      this.endOfPostsScroll =
        children[0].children[0].children[0].children[0].offsetHeight +
        children[0].children[0].children[0].children[1].offsetHeight -
        this.content.el.clientHeight

      // this.userIds$.pipe(first()).subscribe(
      //   userIds => {
      //     if(userIds.length > 0){
      //       this.endOfUsersScroll =
      //       children[0].children[1].children[0].children[0].offsetHeight +
      //       children[0].children[1].children[0].children[1].offsetHeight -
      //       this.content.el.clientHeight
      //     }
      //   }
      // )
    }

  }

}
