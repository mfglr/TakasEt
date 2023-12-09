import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Subject, Subscription, debounceTime } from 'rxjs';

@Component({
  selector: 'app-like-button',
  templateUrl: './like-button.component.html',
  styleUrls: ['./like-button.component.scss'],
})
export class LikeButtonComponent{
  
  @Input() iconFontSize? : number;
  @Input() likeStatus : boolean | null = null;
  
  @Output() commitEvent = new EventEmitter()
  @Output() switchEvent = new EventEmitter()

  subject? : Subject<void>
  subs? : Subscription
  
  ngOnInit(){
    if(this.likeStatus != null){
      this.subject = new Subject<void>()
      this.subs = this.subject.pipe(
        debounceTime(500)
      ).subscribe( () => this.commitEvent.emit() )
    }
  }

  switchLikeStatus(){
    if(this.subject){
      this.switchEvent.emit();
      this.subject.next();
    }    
  }

  ngOnDestroy(){
    if(this.subs)
      this.subs.unsubscribe()
    if(this.subject)
      this.subject.complete()
  }
 
}
