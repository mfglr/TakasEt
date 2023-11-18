import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post-image-slider',
  templateUrl: './post-image-slider.component.html',
  styleUrls: ['./post-image-slider.component.scss']
})
export class PostImageSliderComponent {
  @Input() post? : PostResponse
  @Input() urls : string[] | null = null;
  @Input() currentIndex : number | null = null;
  @Output() loadImageEvent = new EventEmitter<number>();
  @Output() changeIndexEvent = new EventEmitter<number>();

  ngOnInit(){
    this.loadImageEvent.emit(0)
  }
  
  publishIndexOnCircles(index : number){
    this.loadImageEvent.emit(index);
  }
  publishIndexOnIcon(vector : -1 | 1){
    if(this.currentIndex != undefined && this.urls)
      this.loadImageEvent.emit((this.currentIndex + this.urls.length + vector) % this.urls.length)
  }

  random(index : number){
    this.changeIndexEvent.emit(index)
  }

  next(){
    if(this.currentIndex != undefined && this.urls){
      let index = (this.currentIndex + 1) % this.urls.length;
      this.changeIndexEvent.emit(index)
      this.loadImageEvent.emit(index)
      this.loadImageEvent.emit(index)
    }
  }

  prev(){
    if(this.currentIndex != undefined && this.urls){
      let index = (this.currentIndex + this.urls.length - 1) % this.urls.length;
      this.changeIndexEvent.emit(index)
      this.loadImageEvent.emit(index)
      this.loadImageEvent.emit((index + this.urls.length - 1) % this.urls.length)
    }
  }

}
