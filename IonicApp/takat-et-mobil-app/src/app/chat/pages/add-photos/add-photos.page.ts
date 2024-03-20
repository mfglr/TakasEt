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
    <swiper-slide>
      <ion-img src='${this.photos[index].dataUrl}'></ion-img>
    </swiper-slide>
  `;

  photos : Photo[] = [];

  async ngOnInit() {
    this.takeAPhoto();
  }

  takeAPhoto(){

    this.photoService.takeAPhoto()
      .then(photo => {
        console.log(photo);
        // this.photos = [...this.photos,photo]

        // let swiperContainer = this.swiper?.nativeElement.swiper;
        // if(swiperContainer){
        //   let index = this.photos.length-1;
        //   swiperContainer.addSlide(index,this.slideItem(index));
        //   swiperContainer.update();
        // }

      })
      .catch(() => console.log("error"));

  }

}
