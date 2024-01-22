import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, map, mergeMap } from 'rxjs';
import { ProfileFollowingPageState } from './state/reducer';
import { selectActiveIndex } from './state/selectors';
import { changeActiveIndexAction } from './state/actions';

@Component({
  selector: 'app-following',
  templateUrl: './following.page.html',
  styleUrls: ['./following.page.scss'],
})
export class FollowingPage implements OnInit {

  startX = 0;
  deltaX = 0;

  tags = [
    {name : "takipci",icon : undefined},
    {name: "takip",icon : undefined}
  ]


  // userId$ = this.loginStore.select(selectUserId);
  // activeIndex$ = this.profileFollowingPageStore.select(selectActiveIndex);
  // followerIds$ = this.profileStore.select(selectFollowerIds);
  // followedIds$ = this.profileStore.select(selectFollowedIds);

  // ids = [this.followerIds$,this.followedIds$];
  @ViewChild("swiperContainer",{static : true}) swiperContainer? : ElementRef;

  constructor(
    private profileFollowingPageStore : Store<ProfileFollowingPageState>,
  ) { }

  ngOnInit() {
    // this.userId$.pipe(
    //   filter(userId => userId != undefined),
    //   map(userId => userId!),
    //   mergeMap(userId => this.activeIndex$.pipe(
    //     mergeMap(activeIndex => this.ids[activeIndex].pipe(
    //       map(ids => {
    //         if(ids.length == 0){
    //           if(activeIndex == 0) this.profileStore.dispatch(nextFollowersAction())
    //           else this.profileStore.dispatch(nextFollowedsAction())
    //         }
    //       })
    //     ))
    //   ))
    // ).subscribe();
  }

  changeActiveIndex(e : any){
    if(e instanceof CustomEvent){
      this.slideTo(e.detail[0].activeIndex)
      this.profileFollowingPageStore.dispatch(changeActiveIndexAction({activeTab : e.detail[0].activeIndex}))
    }
    else{
      this.slideTo(e)
      this.profileFollowingPageStore.dispatch(changeActiveIndexAction({activeTab : e}))
    }
  }
  slideTo(index : number){
    this.swiperContainer?.nativeElement.swiper.slideTo(index)
  }

  onSliderMove(e : any){
    this.deltaX = e.detail[1].touches[0].clientX - this.startX
  }

  onSliderFirstMove(e : any){
    this.startX = e.detail[0].touches.startX
  }

}
