import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-swiper-header',
  templateUrl: './swiper-header.component.html',
  styleUrls: ['./swiper-header.component.scss'],
})
export class SwiperHeaderComponent  implements OnInit {
  @ViewChild("line",{static : true}) line? : ElementRef;

  @Input() tags? : {name : string | undefined,icon : string | undefined}[]

  @Input() activeIndex? : number | null;
  @Input() deltaX : number = 0;
  @Output() changeActiveIndexEvent = new EventEmitter<number>();

  width : number = 0;
  location : number = 0;
  indexerLength : number = 0;

  constructor() { }

  calculateLocation(){
    if(this.tags && this.tags.length > 0 && this.activeIndex != undefined){
      this.indexerLength = (this.width / this.tags.length)
      this.location = this.activeIndex * this.indexerLength - (this.deltaX / this.tags.length);
    }
  }

  ngOnInit() {
    this.calculateLocation();
  }

  ngOnChanges(){
    this.calculateLocation();
  }

  onClick(activeIndex : number){
    this.activeIndex = activeIndex;
    this.changeActiveIndexEvent.emit(activeIndex);
    this.calculateLocation();
  }

  ngAfterViewChecked(){
    if(this.line){
      this.width = this.line.nativeElement.offsetWidth;
      this.calculateLocation();
    }
  }

}
