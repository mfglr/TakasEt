import { AfterContentInit, Component, ElementRef, EventEmitter, Input, OnChanges, Output, ViewChild } from '@angular/core';
import { Observable, debounceTime, distinctUntilChanged, filter, fromEvent, mergeMap, of } from 'rxjs';
import { Mode } from 'src/app/helpers/mode';
import { Followable } from 'src/app/interfaces/followable';
import { NoContentResponse } from 'src/app/models/responses/no-content-response';

@Component({
  selector: 'app-follow-button',
  templateUrl: './follow-button.component.html',
  styleUrls: ['./follow-button.component.scss']
})
export class FollowButtonComponent implements OnChanges,AfterContentInit{

  @Input() followable? : Followable;
  @Input() followedId? : string;
  @ViewChild("followButton",{static : true}) followButton? : ElementRef
  @Output() value = new EventEmitter<number>();
  public mode? : Mode;
  private methods? : ((x:string) => Observable<NoContentResponse>)[];

  ngOnChanges(){
    if(this.followable && this.followedId){
      this.followable.isFollowed.call(this.followable,this.followedId).subscribe(
        x => {
          this.mode = new Mode(2,x ? 1 : 0)
          this.methods = [this.followable!.unfollow,this.followable!.follow];
        }
      )
    }
  }

  ngAfterContentInit(): void {

    fromEvent(this.followButton?.nativeElement,'click').pipe(
      filter( () => !(!this.mode || !this.methods)),
      mergeMap(() => {
        let next = this.mode!.next();
        this.value.emit(next ? next : -1)
        return of(next)
      }),
      debounceTime(500),
      distinctUntilChanged(),
      mergeMap( (x) => this.methods![x].call(this.followable,this.followedId!))
    ).subscribe();

  }

}
