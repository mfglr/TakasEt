import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectIsModalOpen, selectPostOfModal } from '../state/selectors';
import { PostListState } from '../state/reducer';
import { closeModalAction } from '../state/actions';
import { ViewportScroller } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { takeValueOfPosts } from 'src/app/states/app-entity-state';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss'],
})
export class PostListComponent {
  @ViewChild("postList",{static : true}) postList? : ElementRef;
  @Input() postIds? : number[] | null;
  @Output() nextPageEvent = new EventEmitter();

  postOfModal$ = this.postListStore.select(selectPostOfModal);
  isModalOpen$ = this.postListStore.select(selectIsModalOpen);
  triggerIndex : number | undefined;
  lastRequestedPage : number | undefined;

  constructor(
    private postListStore : Store<PostListState>,
    private viewportScroller: ViewportScroller,
    private router : ActivatedRoute
  ) {}

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

  ngAfterViewInit(){
    this.router.fragment.subscribe(
      fragment =>{
        if(fragment){

          document.getElementById(fragment)?.scrollTo()
          this.viewportScroller.scrollToAnchor(fragment);
        }
      }
    )
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
