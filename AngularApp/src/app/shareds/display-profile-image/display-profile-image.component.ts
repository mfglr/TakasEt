import { Component, Input, OnChanges } from '@angular/core';
import { Observable } from 'rxjs';
import { ProfileImageService } from 'src/app/services/profile-image.service';

@Component({
  selector: 'app-display-profile-image',
  templateUrl: './display-profile-image.component.html',
  styleUrls: ['./display-profile-image.component.scss']
})
export class DisplayProfileImageComponent implements OnChanges {

  @Input() diameter : string = '75';
  @Input() userId : number | null | undefined = null;
  profileImage$? : Observable<string>;

  constructor(
    private profileImageService : ProfileImageService,
  ) {

  }

  ngOnChanges(){
    if(this.userId){
      this.profileImage$ = this.profileImageService.getActiveProfileImage(this.userId);
    }
  }
}
