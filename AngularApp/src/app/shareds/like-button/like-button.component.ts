import { AfterContentInit, Component, ElementRef, EventEmitter, Input, OnChanges, OnDestroy, Output, ViewChild } from '@angular/core';
import { BehaviorSubject, Observable, Subscription, debounceTime, distinctUntilChanged, filter, fromEvent, mergeMap, of} from 'rxjs';
import { Mode } from 'src/app/helpers/mode';
import { Likeable } from 'src/app/interfaces/likeable';
import { NoContentResponse } from 'src/app/models/responses/no-content-response';

@Component({
  selector: 'app-like-button',
  templateUrl: './like-button.component.html',
  styleUrls: ['./like-button.component.scss']
})
export class LikeButtonComponent implements OnChanges,AfterContentInit{

  @Input() id? : number;
  @Input() likeable? : Likeable;
  @Output() likeVector = new EventEmitter<number>();
  @ViewChild("likeButton",{static : true}) likeButton? : ElementRef;
  mode? : Mode;
  private methods? : ((x:number) => Observable<NoContentResponse>)[];
  classes = ['fa-regular fa-heart unlike','fa-solid fa-heart like']

  ngOnChanges(){
    if(this.id && this.likeable){
      this.likeable.isLiked.call(this.likeable,this.id).subscribe(
        x => {
          this.mode = new Mode(2,x ? 1 : 0);
          this.methods = [this.likeable!.unlike,this.likeable!.like];
        }
      )
    }
  }

  ngAfterContentInit(){
    fromEvent(this.likeButton?.nativeElement,'click').pipe(
      filter( () => !(!this.mode || !this.methods)),
      mergeMap(() => {
        let next = this.mode!.next();
        this.likeVector.emit(next ? next : -1)
        return of(next)
      }),
      debounceTime(500),
      distinctUntilChanged(),
      mergeMap( (x) => this.methods![x].call(this.likeable,this.id!))
    ).subscribe();
  }

}
