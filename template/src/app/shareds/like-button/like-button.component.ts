import { Component, Input, OnChanges, OnDestroy } from '@angular/core';
import { BehaviorSubject, Observable, Subscription, debounceTime, distinctUntilChanged, mergeMap, skip } from 'rxjs';
import { Likeable } from 'src/app/interfaces/likeable';
import { NoContentResponse } from 'src/app/models/responses/no-content-response';

@Component({
  selector: 'app-like-button',
  templateUrl: './like-button.component.html',
  styleUrls: ['./like-button.component.scss']
})
export class LikeButtonComponent implements OnDestroy,OnChanges{

  @Input() ownerId? : string;
  @Input() initialValue : number = 0;
  @Input() likeable? : Likeable;
  public currentValue : number = this.initialValue;
  private valueSource$? : BehaviorSubject<number>;
  private methods? : ((x:string) => Observable<NoContentResponse>)[];
  private likeSubscription? : Subscription

  constructor(
  ) {
  }

  ngOnChanges(){
    if(this.ownerId && this.likeable){
      this.currentValue = this.initialValue;
      this.valueSource$ = new BehaviorSubject<number>(this.initialValue);
      this.methods = [this.likeable.unlike,this.likeable.like];
      this.likeSubscription = this.valueSource$.pipe(
        skip(1),
        debounceTime(500),
        distinctUntilChanged(),
        mergeMap(() => this.methods![this.currentValue].call(this.likeable,this.ownerId!))
      ).subscribe();
    }
  }

  switch(){
    this.valueSource$?.next( this.currentValue = (this.currentValue + 1) % 2 )
  }

  ngOnDestroy(): void {
    this.valueSource$?.complete();
    this.likeSubscription?.unsubscribe();
  }

}
