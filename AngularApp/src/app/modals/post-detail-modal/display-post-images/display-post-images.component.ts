import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { GenericMode } from 'src/app/helpers/generic-mode';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-display-post-images',
  templateUrl: './display-post-images.component.html',
  styleUrls: ['./display-post-images.component.scss']
})
export class DisplayPostImagesComponent implements OnChanges {

  @Input() post? : PostResponse;
  @Input() urls? : string[];
  @Output() nextPageOfPostImagesEvent = new EventEmitter<PostResponse>();

  mode = new GenericMode<string>("linear",[]);


  ngOnChanges(changes: SimpleChanges): void {
    if(this.urls) this.mode = new GenericMode<string>("linear",this.urls)
  }

  getNextPageOfPostImages(){
    if(this.post) this.nextPageOfPostImagesEvent.emit(this.post)
  }

  getNextImage(){
    if(this.post && this.urls){
      if(this.mode.currentIndex  == this.urls.length - 1){
        this.getNextPageOfPostImages();
        this.mode.addItem("https://t4.ftcdn.net/jpg/04/73/25/49/360_F_473254957_bxG9yf4ly7OBO5I0O5KABlN930GwaMQz.jpg");
      }
      this.mode.next();
    }

  }
  getPrevImage(){

  }

}
