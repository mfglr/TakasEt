import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-display-profile-image',
  templateUrl: './display-profile-image.component.html',
  styleUrls: ['./display-profile-image.component.scss']
})
export class DisplayProfileImageComponent {
  @Input() url? : string | null;
  @Input() diameter : string = '75';
}
