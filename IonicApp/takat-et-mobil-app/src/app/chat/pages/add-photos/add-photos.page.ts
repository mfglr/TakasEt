import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Photo } from '@capacitor/camera';
import { PhotoService } from 'src/app/services/photo-service';
@Component({
  selector: 'app-add-photos',
  templateUrl: './add-photos.page.html',
  styleUrls: ['./add-photos.page.scss'],
})
export class AddPhotosPage implements OnInit {

  @ViewChild("swiper") swiper? : ElementRef;

  constructor(
    private readonly photoService : PhotoService
  ) { }

  slideItem = (index : number) : string =>
  `
    <swiper-slide class='slide'>
      <div class='img-wrapper'>
        <img class='img' src='${this.photos[index].dataUrl}'/>
      </div>
    </swiper-slide>
  `;

  photos : Photo[] = [];

  async ngOnInit() {
    this.takeAPhoto();
  }

  takeAPhoto(){

    this.photoService.takeAPhoto()
      .then(photo => {
        let swiper = this.swiper?.nativeElement.swiper
        if(swiper){
          this.photos = [...this.photos,photo]
          let index = this.photos.length - 1;
          swiper.addSlide(index,this.slideItem(index));
          swiper.activeIndex = index;
          swiper.update();
        }
      })
      .catch(() => console.log("error"));

  }

}
