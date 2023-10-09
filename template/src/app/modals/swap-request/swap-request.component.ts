import { AfterContentInit, Component, ElementRef, Input, OnChanges, OnDestroy, ViewChild } from '@angular/core';
import { Subscription, filter, from, fromEvent, map, mergeMap, toArray } from 'rxjs';
import { PostResponse } from 'src/app/models/responses/post-response';
import { PostImageService } from 'src/app/services/post-image.service';
import { PostService } from 'src/app/services/post.service';
import { PostPostRequestingService } from 'src/app/services/post-post-requesting.service';

@Component({
  selector: 'app-swap-request',
  templateUrl: './swap-request.component.html',
  styleUrls: ['./swap-request.component.scss']
})
export class SwapRequestComponent implements OnChanges,OnDestroy,AfterContentInit{

  @Input() requestedId : string | null | undefined = null;
  @Input() userId : string | null | undefined = null;
  @ViewChild("requestingButton",{static: true}) swapRequestButton? : ElementRef;
  data? : {post : PostResponse,url : string}[];
  dataSubscription? : Subscription;
  swapRequestButtonSubscription? : Subscription;
  private requesterIds : string[] = [];

  constructor(
    private postService : PostService,
    private postImageService : PostImageService,
    private requestingService : PostPostRequestingService
  ) {}


  selectItems(event : {status : number,index : number}){
    if(this.data){
      let id = this.data[event.index].post.id
      let index = this.requesterIds.findIndex(x => x == id)
      if(index != -1){
        if(!event.status)
          this.requesterIds.splice(index,1);
      }
      else{
        if(event.status)
          this.requesterIds.push(id)
      }
    }
  }

  ngOnChanges() : void{
    if(this.userId){

      this.dataSubscription = this.postService.getPostsByUserId(this.userId).pipe(
        mergeMap( posts => this.postImageService.getFirsImagesOfPostByUserId(this.userId!).pipe(
          mergeMap(urls => from(posts).pipe(
            map((post,index) => ({post:post,url : urls[index]})),
            toArray()
          )),
        ))
      ).subscribe(data => this.data = data)

    }
  }

  ngAfterContentInit(): void {
    this.swapRequestButtonSubscription = fromEvent(this.swapRequestButton?.nativeElement,"click").pipe(
      filter(() => this.requestedId != null && this.requestedId != undefined && this.requesterIds.length > 0 ),
      mergeMap(() => this.requestingService.addSwapRequests(this.requestedId!,this.requesterIds))
    ).subscribe();
  }


  ngOnDestroy(): void {
    this.dataSubscription?.unsubscribe();
    this.swapRequestButtonSubscription?.unsubscribe();
  }



}
