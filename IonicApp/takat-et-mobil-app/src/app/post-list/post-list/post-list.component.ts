import { AfterContentInit, Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectIsModalOpen, selectPostOfModal } from '../state/selectors';
import { PostListState } from '../state/reducer';
import { closeModalAction } from '../state/actions';
import { takeValueOfPosts } from 'src/app/states/app-states';
import { ViewportScroller } from '@angular/common';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss'],
})
export class PostListComponent implements AfterContentInit {
  @ViewChild("postList",{static : true}) postList? : ElementRef;
  @Input() postIds? : number[] | null;
  @Input() startIndex? : number;
  @Output() nextPageEvent = new EventEmitter();

  postOfModal$ = this.postListStore.select(selectPostOfModal);
  isModalOpen$ = this.postListStore.select(selectIsModalOpen);
  triggerIndex : number | undefined;
  lastRequestedPage : number | undefined;

  constructor(
    private postListStore : Store<PostListState>,
    private viewportScroller: ViewportScroller
  ) {}

  ngOnInit(){
    window.addEventListener("load",() => {
      document.getElementById("394")?.scrollIntoView({
        behavior: "smooth",
        block: "start",
        inline: "nearest"
      });
    })

  }


  onScroll(event : any){
    if(this.postIds && this.lastRequestedPage != undefined){
      let triggerIndex = this.postIds.length - takeValueOfPosts / 2;
      let children = this.postList?.nativeElement.children
      if(children[triggerIndex]){
        let triggerOffSet = children[triggerIndex].offsetTop;
        let scrollTop = event.detail.scrollTop
        let requestedPage = this.postIds.length / takeValueOfPosts;
        if(scrollTop >= triggerOffSet && requestedPage > this.lastRequestedPage){
          this.lastRequestedPage = requestedPage;
          this.nextPageEvent.emit();
        }
      }
    }
  }

  ngAfterContentInit(){

  }
  ngOnChanges(){
    if(this.postIds){
      if(!this.lastRequestedPage){
        this.lastRequestedPage = (this.postIds.length / takeValueOfPosts) - 1
      }
    }
  }

  closeModal(){
    this.postListStore.dispatch(closeModalAction())
  }
}
