import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Mode } from 'src/app/helpers/mode';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-swap-request-item',
  templateUrl: './swap-request-item.component.html',
  styleUrls: ['./swap-request-item.component.scss']
})
export class SwapRequestItemComponent {
  @Input() post : PostResponse | null = null
  @Input() imageUrl : string | null = null
  @Input() index : number | null = null;

  @Output() selectEvent = new EventEmitter<{status : number,index : number}>();
  mode : Mode = new Mode(2);

  switch(){
    if(this.index != null){
      this.mode.next();
      this.selectEvent.emit({status : this.mode.currentIndex,index : this.index});
    }
  }


}
