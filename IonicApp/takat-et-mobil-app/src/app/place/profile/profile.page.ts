import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { filter, mergeMap } from 'rxjs';
import { LoginState } from 'src/app/states/login_state/reducer';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { UserState } from 'src/app/states/user-state/reducer';
import { selectUser } from 'src/app/states/user-state/selectors';
import { ProfilePageState } from './state/reducer';
import { nextPageAction } from './state/actions';
import { selectActiveTab, selectPostIds } from './state/selectors';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit{

  user$ = this.loginStore.select(selectUserId).pipe(
    filter(userId => userId != undefined),
    mergeMap(userId => this.userStore.select(selectUser({id : userId!})))
  )
  activeTab$? = this.profilePageStore.select(selectActiveTab);

  @ViewChild("swiperContainer") swiperContainer? : ElementRef;
  postIds$ = this.profilePageStore.select(selectPostIds)

  constructor(
    private loginStore : Store<LoginState>,
    private userStore : Store<UserState>,
    private profilePageStore : Store<ProfilePageState>
  ) { }

  ngOnInit() {
    this.profilePageStore.dispatch(nextPageAction())
  }
  
  ngAfterContentInit(){
    this.activeTab$?.subscribe(
      x => this.slideTo(x)
    )
  }
  slideTo(index : number){
    this.swiperContainer?.nativeElement.swiper.slideTo(index)
  }

  onSliderMove(e : any){
    let start = e.detail[0].touches.startX;
    let current = e.detail[0].touches.currentX;
  }
}
