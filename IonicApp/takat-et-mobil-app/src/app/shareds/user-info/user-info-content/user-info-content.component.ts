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
  @Input() activeIndex? : number | null;
  @Input() postIds? : number[] | null;
  @Input() swappedPostIds? : number[] | null;
  @Input() notSwappedPostIds? : number[] | null;
  @Input() tags? : {name : string| undefined,icon : string| undefined}[];
  @Output() changeActiveIndexEvent = new EventEmitter<number>();
  @ViewChild("swiperContainer") swiperContainer? : ElementRef;

  constructor() { }

  ngOnInit() {
  }

  ngAfterContentInit(){
    if(this.activeIndex){
      this.slideTo(this.activeIndex)
    }
  }

  slideTo(index : number){
    this.swiperContainer?.nativeElement.swiper.slideTo(index)
  }

  changeActiveIndex(e : any){
    if(e instanceof CustomEvent){
      this.changeActiveIndexEvent.emit(e.detail[0].activeIndex)
    }
    else{
      this.changeActiveIndexEvent.emit(e)
      this.slideTo(e);
    }
  }
}
