import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Photo } from '@capacitor/camera';
import { PhotoService } from 'src/app/services/photo-service';
import { UserState } from '../../state/reducer';

@Component({
  selector: 'app-add-photos',
  templateUrl: './add-photos.page.html',
  styleUrls: ['./add-photos.page.scss'],
})
export class AddPhotosPage implements OnInit{
  @Input() useState? : UserState;
  @ViewChild("swiper") swiper? : ElementRef;

  constructor(
    private readonly photoService : PhotoService,
  ) { }


  photos : Photo[] = [];

  async ngOnInit() {
    this.takeAPhoto();
  }

  ngAfterViewChecked(){
    this.swiper?.nativeElement.swiper.update();
  }

  takeAPhoto(){
    this.photoService.takeAPhoto()
      .then(photo => {
        this.photos.push(photo);
      })
      .catch((e) => console.log(e));
  }

  addPhoto(photo : Photo){
    this.photos.push(photo);
    var swiperContainer = this.swiper?.nativeElement.swiper;
    if(swiperContainer && this.photos.length > 0)
      swiperContainer.activeIndex = this.photos.length - 1
  }

  removePhoto(index : number){
    if(index > -1 && index < this.photos.length){
      this.photos.splice(index,1);
    }
  }

}
