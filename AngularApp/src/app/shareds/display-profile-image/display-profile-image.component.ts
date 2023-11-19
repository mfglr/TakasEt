import { Component, Input, OnChanges } from '@angular/core';
import { Observable } from 'rxjs';
import { ProfileImageService } from 'src/app/services/profile-image.service';

@Component({
  selector: 'app-display-profile-image',
  templateUrl: './display-profile-image.component.html',
  styleUrls: ['./display-profile-image.component.scss']
})
export class DisplayProfileImageComponent{

  @Input() diameter : string = '75';
  @Input() url? : string | null;

}
