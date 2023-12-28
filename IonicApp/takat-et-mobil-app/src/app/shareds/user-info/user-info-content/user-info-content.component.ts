import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-user-info-content',
  templateUrl: './user-info-content.component.html',
  styleUrls: ['./user-info-content.component.scss'],
})
export class UserInfoContentComponent  implements OnInit {
  @Input() postListUrl? : string;
  @Input() user? : UserResponse | null;
  @Input() activeTab? : number | null;
  @Input() postIds? : number[] | null;
  @Input() swappedPostIds? : number[] | null;
  @Input() notSwappedPostIds? : number[] | null;
  @Output() changeActiveTabEvent = new EventEmitter<number>();
  @ViewChild("swiperContainer") swiperContainer? : ElementRef;

  constructor() { }

  ngOnInit() {
  }

  ngAfterContentInit(){
    if(this.activeTab){
      this.slideTo(this.activeTab)
    }
  }

  slideTo(index : number){
    this.swiperContainer?.nativeElement.swiper.slideTo(index)
  }

  changeActiveTab(e : any){
    this.changeActiveTabEvent.emit(e.detail[0].activeIndex)
  }
}
