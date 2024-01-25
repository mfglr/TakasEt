import { Component, OnInit } from '@angular/core';
import { PhotoService } from 'src/app/services/photo.service';

@Component({
  selector: 'app-create-story',
  templateUrl: './create-story.page.html',
  styleUrls: ['./create-story.page.scss'],
})
export class CreateStoryPage implements OnInit {

  constructor(
    private photoService : PhotoService
  ) { }

  ngOnInit() {
  }

  takeAPhoto(){
    this.photoService.takeAPhoto().subscribe(
      data => console.log(data)
    )
  }

}
