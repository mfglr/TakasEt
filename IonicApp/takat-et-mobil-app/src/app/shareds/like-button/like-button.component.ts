import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-like-button',
  templateUrl: './like-button.component.html',
  styleUrls: ['./like-button.component.scss'],
})
export class LikeButtonComponent{
  @Input() fontSize? : number;
  @Input() likeStatus? : boolean;
  @Output() switchLikeStatusEvent = new EventEmitter()

  switchLikeStatus(){
    this.switchLikeStatusEvent.emit();
  }
 
}
