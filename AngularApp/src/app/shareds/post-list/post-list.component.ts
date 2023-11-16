import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent{
  @ViewChild("commentModalButton",{static : true}) commentModalButton? : ElementRef;
  @Output() nextPageOfPosts = new EventEmitter<void>();

  @Input() posts : PostResponse[] | null = null
  postWithCommentDisplayed? : PostResponse;

  constructor(
  ) {}

  displayComments(post : PostResponse){
    this.postWithCommentDisplayed = post;
    if(this.commentModalButton)
      this.commentModalButton.nativeElement.click();
  }

  getMore(){
    this.nextPageOfPosts.emit();
  }

}
